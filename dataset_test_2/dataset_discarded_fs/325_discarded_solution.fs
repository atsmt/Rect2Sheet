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
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(-40.000000, 43.970600) * millimeter, vector(-50.000000, 43.970600) * millimeter, vector(-50.000000, 80.882400) * millimeter, vector(-40.000000, 80.882400) * millimeter, vector(0.000000, 55.000000) * millimeter, vector(100.000000, 55.000000) * millimeter, vector(100.000000, -10.000000) * millimeter, vector(0.000000, -10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(-40.000000, 43.970600) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(31.471872, 28.692982, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0_0 (two_bend) ===
        // Flange 0_0->3_0_0_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_3_0_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, -10.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 3_0_0_1
        var sketchRem3_0_0_1a = newSketchOnPlane(context, id + "sketchRem3_0_0_1a", { "sketchPlane" : plane(vector(0.0, -10.0, -10.0) * millimeter, vector(0.0, 1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem3_0_0_1a, "polyRem3_0_0_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-220.000000, -40.000000) * millimeter, vector(-218.000000, -50.000000) * millimeter, vector(-18.000000, -50.000000) * millimeter, vector(-20.000000, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_0_1a);
        sheetMetalTab(context, id + "smTab3_0_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_0_1a"), vector(50.000000, -10.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_3_0_0_1a", EntityType.FACE), vector(50.000000, -10.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_0_1->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, -10.000000, -130.000000) * millimeter),
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
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(2.000000, -10.000000) * millimeter, vector(-118.000000, -10.000000) * millimeter, vector(-120.000000, 0.000000) * millimeter, vector(-120.000000, 200.000000) * millimeter, vector(8.000000, 200.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(-50.000000, -5.000000, -130.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_0_0_1_1b", EntityType.FACE), vector(-50.000000, -5.000000, -130.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0_0 (one_bend) ===
        // Flange 0_0->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, 62.426500, 0.000000) * millimeter),
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
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(-50.0, 40.0, 30.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(3.970600, -20.000000) * millimeter, vector(3.970600, -28.000000) * millimeter, vector(40.882400, -28.000000) * millimeter, vector(40.882400, -20.000000) * millimeter, vector(70.000000, 0.000000) * millimeter, vector(70.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(-50.000000, 62.426500, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_2", EntityType.FACE), vector(-50.000000, 62.426500, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });