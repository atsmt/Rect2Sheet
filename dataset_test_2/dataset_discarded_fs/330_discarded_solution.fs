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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(100.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, -10.000000) * millimeter, vector(100.000000, -10.000000) * millimeter, vector(100.000000, 0.000000) * millimeter, vector(140.000000, 29.411800) * millimeter, vector(150.000000, 29.411800) * millimeter, vector(150.000000, 108.965500) * millimeter, vector(140.000000, 108.965500) * millimeter, vector(100.000000, 120.000000) * millimeter, vector(100.000000, 130.000000) * millimeter, vector(0.000000, 130.000000) * millimeter, vector(0.000000, -10.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(31.393219, 61.299190, 0.000000) * millimeter),
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
        // Flange 0->1_0_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, -10.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0_1
        var sketchRem1_0_1a = newSketchOnPlane(context, id + "sketchRem1_0_1a", { "sketchPlane" : plane(vector(0.0, -10.0, -10.0) * millimeter, vector(0.0, 1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_0_1a, "polyRem1_0_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-220.000000, -40.000000) * millimeter, vector(-218.000000, -50.000000) * millimeter, vector(-18.000000, -50.000000) * millimeter, vector(-20.000000, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1a);
        sheetMetalTab(context, id + "smTab1_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1a"), vector(50.000000, -10.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_1a", EntityType.FACE), vector(50.000000, -10.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, -10.000000, -130.000000) * millimeter),
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
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(-50.0, 0.0, -30.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(-120.000000, 0.000000) * millimeter, vector(-120.000000, 200.000000) * millimeter, vector(8.000000, 200.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(-120.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(-50.000000, -5.000000, -130.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_1_1b", EntityType.FACE), vector(-50.000000, -5.000000, -130.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_0 from 0 (one_bend) ===
        // Flange 0->2_0: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2_0", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, 69.188650, 0.000000) * millimeter),
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

        // Remaining polygon for tab 2_0
        var sketchRem2_0 = newSketchOnPlane(context, id + "sketchRem2_0", { "sketchPlane" : plane(vector(-50.0, 110.0, 30.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem2_0, "polyRem2_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-70.000000, 0.000000) * millimeter, vector(-1.034500, -20.000000) * millimeter, vector(-1.034500, -28.000000) * millimeter, vector(-80.588200, -28.000000) * millimeter, vector(-80.588200, -20.000000) * millimeter, vector(-70.000000, 95.000000) * millimeter, vector(0.000000, 95.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_0);
        sheetMetalTab(context, id + "smTab2_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_0"), vector(-50.000000, 69.188650, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2_0", EntityType.FACE), vector(-50.000000, 69.188650, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_1 from 0 (two_bend) ===
        // Flange 0->1_0_2_1: bend=92.49deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, 130.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 92.487413 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_2_1
        var wallFace1_0_2_1a = qClosestTo(qCreatedBy(id + "flange0_1_0_2_1a", EntityType.FACE), vector(50.000000, 129.783000, 4.995289) * millimeter);
        var faceN1_0_2_1a = evPlane(context, { "face" : wallFace1_0_2_1a }).normal;
        var skN1_0_2_1a = dot(faceN1_0_2_1a, vector(0.0, -0.9990577803, -0.0433999036)) >= 0 ? faceN1_0_2_1a : -faceN1_0_2_1a;
        var sketchRem1_0_2_1a = newSketchOnPlane(context, id + "sketchRem1_0_2_1a", { "sketchPlane" : plane(vector(0.0, 129.566, 9.9906) * millimeter, skN1_0_2_1a, vector(0.0, 0.0433999036, -0.9990577803)) });
        skPolyline(sketchRem1_0_2_1a, "polyRem1_0_2_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000022, 0.000000) * millimeter, vector(8.000022, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-223.688926, -40.000000) * millimeter, vector(-221.688926, -50.000000) * millimeter, vector(-123.740756, -50.000000) * millimeter, vector(-125.740756, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2_1a);
        sheetMetalTab(context, id + "smTab1_0_2_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2_1a"), vector(0.000000, 129.783000, 4.995289) * millimeter),
            "booleanUnionScope" : wallFace1_0_2_1a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2_1->2_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_1_2_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, 121.984050, 184.540850) * millimeter),
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
        var sketchRem2_1b = newSketchOnPlane(context, id + "sketchRem2_1b", { "sketchPlane" : plane(vector(-50.0, 110.0, 135.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem2_1b, "polyRem2_1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(70.000000, 0.000000) * millimeter, vector(70.000000, 95.000000) * millimeter, vector(0.131800, 98.034900) * millimeter, vector(-7.860684, 98.382009) * millimeter, vector(-12.111184, 0.526109) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_1b);
        sheetMetalTab(context, id + "smTab2_1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_1b"), vector(-50.000000, 116.988760, 184.323873) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_2_1_2_1b", EntityType.FACE), vector(-50.000000, 116.988760, 184.323873) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });