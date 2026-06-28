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
        skPolyline(sketch0, "poly0", { "points" : [vector(100.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(0.000000, 390.000000) * millimeter, vector(100.000000, 390.000000) * millimeter, vector(100.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(50.000000, 195.000000, 0.000000) * millimeter),
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

        // === Child Tab 2 from 1 (two_bend) ===
        // Flange 1->1_1_2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, 390.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_1_2
        var sketchRem1_1_2a = newSketchOnPlane(context, id + "sketchRem1_1_2a", { "sketchPlane" : plane(vector(100.0, 390.0, -10.0) * millimeter, vector(0.0, -1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_1_2a, "polyRem1_1_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-130.000000, -40.000000) * millimeter, vector(-128.000000, -50.000000) * millimeter, vector(-8.000000, -50.000000) * millimeter, vector(-10.000000, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_2a);
        sheetMetalTab(context, id + "smTab1_1_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_2a"), vector(50.000000, 390.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_1_1_2a", EntityType.FACE), vector(50.000000, 390.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_2->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(150.000000, 390.000000, -80.000000) * millimeter),
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
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(150.0, 350.0, -20.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(53.419000, -55.294000) * millimeter, vector(65.257700, -57.082800) * millimeter, vector(50.602200, -137.688400) * millimeter, vector(38.763500, -135.899600) * millimeter, vector(-100.000000, 0.000000) * millimeter, vector(-100.000000, 120.000000) * millimeter, vector(38.000000, 120.000000) * millimeter, vector(38.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(150.000000, 385.000000, -80.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_1_2_2b", EntityType.FACE), vector(150.000000, 385.000000, -80.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 2 (one_bend) ===
        // Flange 2->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(150.000000, 405.929950, 77.385600) * millimeter),
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
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(0.0, 412.8446, 39.3548) * millimeter, vector(0.0, 0.9838701158, 0.1788843068), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-100.000000, 0.000000) * millimeter, vector(-140.000000, -2.309250) * millimeter, vector(-148.000000, -2.309250) * millimeter, vector(-148.000000, 79.617830) * millimeter, vector(-140.000000, 79.617830) * millimeter, vector(-100.000000, 139.999984) * millimeter, vector(0.000000, 139.999984) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(145.000000, 405.929950, 77.385600) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange2_3", EntityType.FACE), vector(145.000000, 405.929950, 77.385600) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });