FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(200.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(210.000000, 0.000000) * millimeter, vector(210.000000, 200.000000) * millimeter, vector(200.000000, 200.000000) * millimeter, vector(220.000000, 218.493200) * millimeter, vector(230.000000, 218.493200) * millimeter, vector(230.000000, 302.588500) * millimeter, vector(220.000000, 302.588500) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(84.783655, 130.213560, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 1 from 0 (two_bend) ===
        // Flange 0->1_0_1: bend=123.69deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 100.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 123.690068 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_0_1
        var wallFace1_0_1a = qClosestTo(qCreatedBy(id + "flange0_1_0_1a", EntityType.FACE), vector(-12.773501, 100.000000, -4.160251) * millimeter);
        var faceN1_0_1a = evPlane(context, { "face" : wallFace1_0_1a }).normal;
        var skN1_0_1a = dot(faceN1_0_1a, vector(-0.8320502943, 0.0, 0.5547001962)) >= 0 ? faceN1_0_1a : -faceN1_0_1a;
        var sketchRem1_0_1a = newSketchOnPlane(context, id + "sketchRem1_0_1a", { "sketchPlane" : plane(vector(-15.547, 0.0, -8.3205) * millimeter, skN1_0_1a, vector(0.5547001962, 0.0, 0.8320502943)) });
        skPolyline(sketchRem1_0_1a, "polyRem1_0_1a", { "points" : [vector(7.999996, 0.000000) * millimeter, vector(7.999996, 200.000000) * millimeter, vector(-24.055516, 200.000000) * millimeter, vector(-24.055516, 0.000000) * millimeter, vector(7.999996, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1a);
        sheetMetalTab(context, id + "smTab1_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1a"), vector(-12.773501, 0.000000, -4.160251) * millimeter),
            "booleanUnionScope" : wallFace1_0_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1->1: bend=146.31deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-30.000000, 100.000000, -30.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 146.309932 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var wallFace1b = qClosestTo(qCreatedBy(id + "flange1_0_1_1b", EntityType.FACE), vector(-30.000000, 100.000000, -35.000000) * millimeter);
        var faceN1b = evPlane(context, { "face" : wallFace1b }).normal;
        var skN1b = dot(faceN1b, vector(-1.0, 0.0, 0.0)) >= 0 ? faceN1b : -faceN1b;
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(-30.0, 0.0, -40.0) * millimeter, skN1b, vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(200.000000, -8.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(210.000000, -2.000000) * millimeter, vector(210.000000, 118.000000) * millimeter, vector(200.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(-30.000000, 100.000000, -40.000000) * millimeter),
            "booleanUnionScope" : wallFace1b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_1 from 0 (one_bend) ===
        // Flange 0->2_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-30.000000, 260.540850, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2_1
        var sketchRem2_1 = newSketchOnPlane(context, id + "sketchRem2_1", { "sketchPlane" : plane(vector(-30.0, 315.0, -150.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem2_1, "polyRem2_1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(70.000000, 0.000000) * millimeter, vector(140.000000, -96.506800) * millimeter, vector(148.000000, -96.506800) * millimeter, vector(148.000000, -12.411500) * millimeter, vector(140.000000, -12.411500) * millimeter, vector(70.000000, 35.000000) * millimeter, vector(0.000000, 35.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_1);
        sheetMetalTab(context, id + "smTab2_1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_1"), vector(-30.000000, 260.540850, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2_1", EntityType.FACE), vector(-30.000000, 260.540850, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_0 from 1 (two_bend) ===
        // Flange 1->1_1_2_0: bend=112.62deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_2_0a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-30.000000, 210.000000, -100.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 112.619865 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_1_2_0
        var wallFace1_1_2_0a = qClosestTo(qCreatedBy(id + "flange1_1_1_2_0a", EntityType.FACE), vector(-30.000000, 215.000000, -100.000000) * millimeter);
        var faceN1_1_2_0a = evPlane(context, { "face" : wallFace1_1_2_0a }).normal;
        var skN1_1_2_0a = dot(faceN1_1_2_0a, vector(1.0, 0.0, 0.0)) >= 0 ? faceN1_1_2_0a : -faceN1_1_2_0a;
        var sketchRem1_1_2_0a = newSketchOnPlane(context, id + "sketchRem1_1_2_0a", { "sketchPlane" : plane(vector(-30.0, 210.0, -40.0) * millimeter, skN1_1_2_0a, vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem1_1_2_0a, "polyRem1_1_2_0a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(120.000000, 0.000000) * millimeter, vector(110.000000, 50.000000) * millimeter, vector(40.000000, 50.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_2_0a);
        sheetMetalTab(context, id + "smTab1_1_2_0a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_2_0a"), vector(-30.000000, 210.000000, -100.000000) * millimeter),
            "booleanUnionScope" : wallFace1_1_2_0a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_2_0->2_0: bend=98.51deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2_0_2_0b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-30.000000, 260.000000, -115.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 98.506928 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2_0
        var wallFace2_0b = qClosestTo(qCreatedBy(id + "flange1_1_2_0_2_0b", EntityType.FACE), vector(-30.000000, 265.000000, -115.000000) * millimeter);
        var faceN2_0b = evPlane(context, { "face" : wallFace2_0b }).normal;
        var skN2_0b = dot(faceN2_0b, vector(-1.0, 0.0, 0.0)) >= 0 ? faceN2_0b : -faceN2_0b;
        var sketchRem2_0b = newSketchOnPlane(context, id + "sketchRem2_0b", { "sketchPlane" : plane(vector(-30.0, 270.0, -150.0) * millimeter, skN2_0b, vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem2_0b, "polyRem2_0b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(70.000000, -8.000000) * millimeter, vector(70.000000, 35.000000) * millimeter, vector(0.000000, 35.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem2_0b);
        sheetMetalTab(context, id + "smTab2_0b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_0b"), vector(-30.000000, 270.000000, -115.000000) * millimeter),
            "booleanUnionScope" : wallFace2_0b,
            "booleanOffset" : 0.0 * millimeter
        });
    });