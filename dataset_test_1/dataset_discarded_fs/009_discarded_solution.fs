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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(82.800000, -20.000000) * millimeter, vector(82.800000, -30.000000) * millimeter, vector(167.753800, -30.000000) * millimeter, vector(167.753800, -20.000000) * millimeter, vector(160.000000, 0.000000) * millimeter, vector(180.000000, 0.000000) * millimeter, vector(180.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(66.524054, 25.018291, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-20.000000, 35.000000, 0.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(-20.0, 0.0, -40.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(0.000000, -38.000000) * millimeter, vector(70.000000, -38.000000) * millimeter, vector(70.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-20.000000, 88.088200) * millimeter, vector(-30.000000, 86.088200) * millimeter, vector(-30.000000, 24.470600) * millimeter, vector(-20.000000, 26.470600) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(-20.000000, 35.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(-20.000000, 35.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_1 from 0 (one_bend) ===
        // Flange 0->2_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(34.723100, -30.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 2_1
        var sketchRem2_1 = newSketchOnPlane(context, id + "sketchRem2_1", { "sketchPlane" : plane(vector(-70.0, -30.0, -40.0) * millimeter, vector(0.0, -1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem2_1, "polyRem2_1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(30.000000, -62.246200) * millimeter, vector(38.000000, -62.246200) * millimeter, vector(38.000000, -147.200000) * millimeter, vector(30.000000, -147.200000) * millimeter, vector(-45.000000, 0.000000) * millimeter, vector(-45.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_1);
        sheetMetalTab(context, id + "smTab2_1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_1"), vector(34.723100, -30.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2_1", EntityType.FACE), vector(34.723100, -30.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2_0 from 1 (one_bend) ===
        // Flange 1->2_0: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2_0", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-20.000000, -30.000000, -97.279400) * millimeter),
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
        var sketchRem2_0 = newSketchOnPlane(context, id + "sketchRem2_0", { "sketchPlane" : plane(vector(-70.0, -30.0, -95.0) * millimeter, vector(0.0, -1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem2_0, "polyRem2_0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(28.529400, -40.000000) * millimeter, vector(28.529400, -48.000000) * millimeter, vector(-33.088200, -48.000000) * millimeter, vector(-33.088200, -40.000000) * millimeter, vector(-45.000000, 0.000000) * millimeter, vector(-45.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2_0);
        sheetMetalTab(context, id + "smTab2_0", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2_0"), vector(-25.000000, -30.000000, -97.279400) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_2_0", EntityType.FACE), vector(-25.000000, -30.000000, -97.279400) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });