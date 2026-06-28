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

        // === Root Tab 0_0 ===
        var sketch0_0 = newSketchOnPlane(context, id + "sketch0_0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(0.000000, 100.000000) * millimeter, vector(60.344800, 140.000000) * millimeter, vector(60.344800, 150.000000) * millimeter, vector(154.137900, 150.000000) * millimeter, vector(154.137900, 140.000000) * millimeter, vector(180.000000, 100.000000) * millimeter, vector(190.000000, 100.000000) * millimeter, vector(190.000000, 55.000000) * millimeter, vector(0.000000, 55.000000) * millimeter, vector(0.000000, 100.000000) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(96.761148, 96.515247, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0_0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0_0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 2 from 0_0 (two_bend) ===
        // Flange 0_0->3_0_0_2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_3_0_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(190.000000, 22.500000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 3_0_0_2
        var sketchRem3_0_0_2a = newSketchOnPlane(context, id + "sketchRem3_0_0_2a", { "sketchPlane" : plane(vector(190.0, 45.0, 10.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem3_0_0_2a, "polyRem3_0_0_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 45.000000) * millimeter, vector(0.000000, 45.000000) * millimeter, vector(-80.000000, -95.000000) * millimeter, vector(-78.000000, -105.000000) * millimeter, vector(-8.000000, -105.000000) * millimeter, vector(-10.000000, -95.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_0_2a);
        sheetMetalTab(context, id + "smTab3_0_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_0_2a"), vector(190.000000, 22.500000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_3_0_0_2a", EntityType.FACE), vector(190.000000, 22.500000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_0_2->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(190.000000, 150.000000, 55.000000) * millimeter),
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

        // Remaining polygon for tab 2
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(70.0, 150.0, 20.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-9.655200, -10.000000) * millimeter, vector(-7.655200, -20.000000) * millimeter, vector(86.137900, -20.000000) * millimeter, vector(84.137900, -10.000000) * millimeter, vector(80.000000, 0.000000) * millimeter, vector(118.000000, 0.000000) * millimeter, vector(118.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(185.000000, 150.000000, 55.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_0_0_2_2b", EntityType.FACE), vector(185.000000, 150.000000, 55.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 1 from 0_1 (two_bend) ===
        // Flange 0_1->3_0_1_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_3_0_1_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(190.000000, 77.500000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 3_0_1_1
        var sketchRem3_0_1_1a = newSketchOnPlane(context, id + "sketchRem3_0_1_1a", { "sketchPlane" : plane(vector(190.0, 55.0, -10.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem3_0_1_1a, "polyRem3_0_1_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 45.000000) * millimeter, vector(0.000000, 45.000000) * millimeter, vector(-200.000000, -75.000000) * millimeter, vector(-198.000000, -85.000000) * millimeter, vector(-38.000000, -85.000000) * millimeter, vector(-40.000000, -75.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_1_1a);
        sheetMetalTab(context, id + "smTab3_0_1_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_1_1a"), vector(190.000000, 77.500000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_3_0_1_1a", EntityType.FACE), vector(190.000000, 77.500000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_1_1->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_1_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(190.000000, -30.000000, -130.000000) * millimeter),
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
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(180.0, -30.0, -50.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(-180.000000, 0.000000) * millimeter, vector(-180.000000, 160.000000) * millimeter, vector(8.000000, 160.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(-180.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(185.000000, -30.000000, -130.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_0_1_1_1b", EntityType.FACE), vector(185.000000, -30.000000, -130.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });