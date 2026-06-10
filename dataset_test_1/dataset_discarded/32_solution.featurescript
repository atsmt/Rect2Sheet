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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(160.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(160.000000, 0.000000) * millimeter, vector(160.000000, 70.000000) * millimeter, vector(-10.000000, 70.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(160.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(85.000000, 35.000000, 0.000000) * millimeter),
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
        // Flange 0->1_0_1: bend=141.71deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(170.000000, 35.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 141.709837 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_1
        var wallFace1_0_1a = qClosestTo(qCreatedBy(id + "flange0_1_0_1a", EntityType.FACE), vector(166.075586, 35.000000, -3.098221) * millimeter);
        var faceN1_0_1a = evPlane(context, { "face" : wallFace1_0_1a }).normal;
        var skN1_0_1a = dot(faceN1_0_1a, vector(0.6196442886, 0.0, -0.7848827655)) >= 0 ? faceN1_0_1a : -faceN1_0_1a;
        var sketchRem1_0_1a = newSketchOnPlane(context, id + "sketchRem1_0_1a", { "sketchPlane" : plane(vector(162.1511723447, 70.0, -6.1964428858) * millimeter, skN1_0_1a, vector(0.7848827655, 0.0, 0.6196442886)) });
        skPolyline(sketchRem1_0_1a, "polyRem1_0_1a", { "points" : [vector(8.000000, 0.000000) * millimeter, vector(8.000000, 70.000000) * millimeter, vector(-230.074369, 70.000000) * millimeter, vector(-230.074369, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1a);
        sheetMetalTab(context, id + "smTab1_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1a"), vector(166.075586, 70.000000, -3.098221) * millimeter),
            "booleanUnionScope" : wallFace1_0_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1->1: bend=128.29deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-20.000000, 35.000000, -150.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 128.290163 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1
        var wallFace1b = qClosestTo(qCreatedBy(id + "flange1_0_1_1b", EntityType.FACE), vector(-20.000000, 35.000000, -145.000000) * millimeter);
        var faceN1b = evPlane(context, { "face" : wallFace1b }).normal;
        var skN1b = dot(faceN1b, vector(-1.0, 0.0, 0.0)) >= 0 ? faceN1b : -faceN1b;
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(-20.0, 0.0, -40.0) * millimeter, skN1b, vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(70.000000, 0.000000) * millimeter, vector(70.000000, 108.000000) * millimeter, vector(0.000000, 108.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-20.000000, 100.000000) * millimeter, vector(-30.000000, 102.000000) * millimeter, vector(-30.000000, 2.000000) * millimeter, vector(-20.000000, 0.000000) * millimeter, vector(70.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(-20.000000, 35.000000, -40.000000) * millimeter),
            "booleanUnionScope" : wallFace1b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1 (one_bend) ===
        // Flange 1->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-20.000000, -30.000000, -90.000000) * millimeter),
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

        // Remaining polygon for tab 2
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(-70.0, -30.0, -140.0) * millimeter, vector(0.0, -1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, -48.000000) * millimeter, vector(100.000000, -48.000000) * millimeter, vector(100.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, -48.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(-25.000000, -30.000000, -90.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_2", EntityType.FACE), vector(-25.000000, -30.000000, -90.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });