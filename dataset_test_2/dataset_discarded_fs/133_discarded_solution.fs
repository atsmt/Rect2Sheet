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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(65.000000, -10.000000) * millimeter, vector(65.000000, -20.000000) * millimeter, vector(95.000000, -20.000000) * millimeter, vector(95.000000, -10.000000) * millimeter, vector(140.000000, 0.000000) * millimeter, vector(140.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(70.418042, 45.687569, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0 (one_bend) ===
        // Flange 0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(80.000000, -20.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(50.0, -20.0, -20.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(15.000000, -10.000000) * millimeter, vector(15.000000, -18.000000) * millimeter, vector(45.000000, -18.000000) * millimeter, vector(45.000000, -10.000000) * millimeter, vector(80.000000, 0.000000) * millimeter, vector(80.000000, 80.000000) * millimeter, vector(58.823500, 120.000000) * millimeter, vector(58.823500, 128.000000) * millimeter, vector(21.176500, 128.000000) * millimeter, vector(21.176500, 120.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(80.000000, -20.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(80.000000, -20.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1 (one_bend) ===
        // Flange 1->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(90.000000, -20.000000, -150.000000) * millimeter),
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
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(130.0, -50.0, -150.0) * millimeter, vector(0.0, 0.0, -1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-21.176500, -20.000000) * millimeter, vector(-21.176500, -28.000000) * millimeter, vector(-58.823500, -28.000000) * millimeter, vector(-58.823500, -20.000000) * millimeter, vector(-80.000000, 0.000000) * millimeter, vector(-90.000000, 2.000000) * millimeter, vector(-90.000000, 162.000000) * millimeter, vector(-80.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(90.000000, -25.000000, -150.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_2", EntityType.FACE), vector(90.000000, -25.000000, -150.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 2 (two_bend) ===
        // Flange 2->1_2_3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_1_2_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(40.000000, -130.000000, -150.000000) * millimeter),
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

        // Remaining polygon for tab 1_2_3
        var sketchRem1_2_3a = newSketchOnPlane(context, id + "sketchRem1_2_3a", { "sketchPlane" : plane(vector(40.0, -50.0, -140.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem1_2_3a, "polyRem1_2_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(-110.000000, -30.000000) * millimeter, vector(-108.000000, -40.000000) * millimeter, vector(-38.000000, -40.000000) * millimeter, vector(-40.000000, -30.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_2_3a);
        sheetMetalTab(context, id + "smTab1_2_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_2_3a"), vector(40.000000, -130.000000, -145.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange2_1_2_3a", EntityType.FACE), vector(40.000000, -130.000000, -145.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_2_3->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(40.000000, -10.000000, -65.000000) * millimeter),
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

        // Remaining polygon for tab 3
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(130.0, -10.0, -100.0) * millimeter, vector(0.0, 1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(88.000000, 0.000000) * millimeter, vector(88.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(45.000000, -10.000000, -65.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_2_3_3b", EntityType.FACE), vector(45.000000, -10.000000, -65.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });