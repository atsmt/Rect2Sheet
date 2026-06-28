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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(120.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(36.923100, -10.000000) * millimeter, vector(36.923100, -20.000000) * millimeter, vector(83.076900, -20.000000) * millimeter, vector(83.076900, -10.000000) * millimeter, vector(120.000000, 0.000000) * millimeter, vector(120.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(60.000000, 94.476889, 0.000000) * millimeter),
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

        // === Child Tab 2_0 from 0 (one_bend) ===
        // Flange 0->2_0: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2_0", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(60.000000, -20.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2_0
        var sketchRem2_0 = newSketchOnPlane(context, id + "sketchRem2_0", { "sketchPlane" : plane(vector(0.0, -20.0, -30.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2_0, "polyRem2_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-36.923100, -20.000000) * millimeter, vector(-36.923100, -28.000000) * millimeter, vector(-83.076900, -28.000000) * millimeter, vector(-83.076900, -20.000000) * millimeter, vector(-120.000000, 0.000000) * millimeter, vector(-120.000000, 45.000000) * millimeter, vector(0.000000, 45.000000) * millimeter, vector(10.000000, 38.000000) * millimeter, vector(20.000000, 36.000000) * millimeter, vector(20.000000, -1.901000) * millimeter, vector(10.000000, 0.099000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_0);
        sheetMetalTab(context, id + "smTab2_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_0"), vector(60.000000, -20.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2_0", EntityType.FACE), vector(60.000000, -20.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1 from 2_0 (one_bend) ===
        // Flange 2_0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-20.000000, -20.000000, -49.049500) * millimeter),
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

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(-20.0, 20.0, -40.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(-12.000000, 11.200000) * millimeter, vector(-12.000000, 120.000000) * millimeter, vector(160.000000, 120.000000) * millimeter, vector(160.000000, 0.000000) * millimeter, vector(-30.000000, -9.901000) * millimeter, vector(-38.000000, -9.901000) * millimeter, vector(-38.000000, 28.000000) * millimeter, vector(-30.000000, 28.000000) * millimeter, vector(-12.000000, 11.200000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(-20.000000, -15.000000, -49.049500) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange2_0_1", EntityType.FACE), vector(-20.000000, -15.000000, -49.049500) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_1 from 1 (two_bend) ===
        // Flange 1->1_1_2_1: bend=18.44deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_2_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-20.000000, 10.000000, -100.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 18.435130 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_1_2_1
        var wallFace1_1_2_1a = qClosestTo(qCreatedBy(id + "flange1_1_1_2_1a", EntityType.FACE), vector(-18.418846, 5.256589, -100.000000) * millimeter);
        var faceN1_1_2_1a = evPlane(context, { "face" : wallFace1_1_2_1a }).normal;
        var skN1_1_2_1a = dot(faceN1_1_2_1a, vector(0.948682298, 0.316230766, 0.0)) >= 0 ? faceN1_1_2_1a : -faceN1_1_2_1a;
        var sketchRem1_1_2_1a = newSketchOnPlane(context, id + "sketchRem1_1_2_1a", { "sketchPlane" : plane(vector(-16.8377, 0.5132, -160.0) * millimeter, skN1_1_2_1a, vector(-0.316230766, 0.948682298, 0.0)) });
        skPolyline(sketchRem1_1_2_1a, "polyRem1_1_2_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999976, 0.000000) * millimeter, vector(7.999976, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(-11.622825, 75.000000) * millimeter, vector(-19.622801, 75.000000) * millimeter, vector(-19.622801, 30.000000) * millimeter, vector(-11.622825, 30.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_2_1a);
        sheetMetalTab(context, id + "smTab1_1_2_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_2_1a"), vector(-18.418846, 5.256589, -160.000000) * millimeter),
            "booleanUnionScope" : wallFace1_1_2_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_2_1->2_1: bend=71.56deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2_1_2_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, -20.000000, -107.500000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 71.564870 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2_1
        var wallFace2_1b = qClosestTo(qCreatedBy(id + "flange1_1_2_1_2_1b", EntityType.FACE), vector(-5.000000, -20.000000, -107.500000) * millimeter);
        var faceN2_1b = evPlane(context, { "face" : wallFace2_1b }).normal;
        var skN2_1b = dot(faceN2_1b, vector(0.0, 1.0, 0.0)) >= 0 ? faceN2_1b : -faceN2_1b;
        var sketchRem2_1b = newSketchOnPlane(context, id + "sketchRem2_1b", { "sketchPlane" : plane(vector(0.0, -20.0, -85.0) * millimeter, skN2_1b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2_1b, "polyRem2_1b", { "points" : [vector(120.000000, 0.000000) * millimeter, vector(120.000000, 45.000000) * millimeter, vector(-8.000000, 45.000000) * millimeter, vector(-8.000000, 0.000000) * millimeter, vector(120.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_1b);
        sheetMetalTab(context, id + "smTab2_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_1b"), vector(-5.000000, -20.000000, -85.000000) * millimeter),
            "booleanUnionScope" : wallFace2_1b,
            "booleanOffset" : 0.0 * millimeter
        });
    });