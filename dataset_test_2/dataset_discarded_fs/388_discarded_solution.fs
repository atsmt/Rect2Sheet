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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(80.882400, -40.000000) * millimeter, vector(80.882400, -50.000000) * millimeter, vector(192.647100, -50.000000) * millimeter, vector(192.647100, -40.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(210.000000, 36.923100) * millimeter, vector(220.000000, 36.923100) * millimeter, vector(220.000000, 83.076900) * millimeter, vector(210.000000, 83.076900) * millimeter, vector(200.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(108.717612, 41.485460, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(220.000000, 60.000000, 0.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(220.0, 0.0, -30.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(36.923100, -20.000000) * millimeter, vector(36.923100, -28.000000) * millimeter, vector(83.076900, -28.000000) * millimeter, vector(83.076900, -20.000000) * millimeter, vector(120.000000, 0.000000) * millimeter, vector(120.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(220.000000, 60.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(220.000000, 60.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0 (one_bend) ===
        // Flange 0->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(136.764750, -50.000000, 0.000000) * millimeter),
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
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(190.0, -50.0, -190.0) * millimeter, vector(0.0, 1.0, 0.0), vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(30.000000, -3.672100) * millimeter, vector(38.000000, -3.672100) * millimeter, vector(38.000000, -65.882400) * millimeter, vector(30.000000, -65.882400) * millimeter, vector(-160.000000, 0.000000) * millimeter, vector(-180.000000, -2.647100) * millimeter, vector(-188.000000, -2.647100) * millimeter, vector(-188.000000, 109.117600) * millimeter, vector(-180.000000, 109.117600) * millimeter, vector(-160.000000, 80.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(136.764750, -50.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_3", EntityType.FACE), vector(136.764750, -50.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 3 (one_bend) ===
        // Flange 3->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(224.777250, -50.000000, -230.000000) * millimeter),
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
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(260.0, 120.0, -230.0) * millimeter, vector(0.0, 0.0, 1.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(160.000000, -66.327900) * millimeter, vector(168.000000, -66.327900) * millimeter, vector(168.000000, -4.117600) * millimeter, vector(160.000000, -4.117600) * millimeter, vector(120.000000, 0.000000) * millimeter, vector(120.000000, 70.000000) * millimeter, vector(0.000000, 70.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(224.777250, -45.000000, -230.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_2", EntityType.FACE), vector(224.777250, -45.000000, -230.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });