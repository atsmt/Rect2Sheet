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
        skPolyline(sketch0, "poly0", { "points" : [vector(-60.000000, 96.538500) * millimeter, vector(-50.000000, 96.538500) * millimeter, vector(-50.000000, 55.000000) * millimeter, vector(-40.000000, 55.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(160.000000, 100.000000) * millimeter, vector(170.000000, 86.206900) * millimeter, vector(180.000000, 86.206900) * millimeter, vector(180.000000, 9.655200) * millimeter, vector(170.000000, 9.655200) * millimeter, vector(160.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(-40.000000, 0.647700) * millimeter, vector(-50.000000, 0.647700) * millimeter, vector(-50.000000, 3.461500) * millimeter, vector(-60.000000, 3.461500) * millimeter, vector(-60.000000, 0.000000) * millimeter, vector(-130.000000, 0.000000) * millimeter, vector(-130.000000, 100.000000) * millimeter, vector(-60.000000, 100.000000) * millimeter, vector(-60.000000, 96.538500) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(26.125637, 48.446918, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(180.000000, 47.931050, 0.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(180.0, 0.0, -50.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(9.655200, -40.000000) * millimeter, vector(9.655200, -48.000000) * millimeter, vector(86.206900, -48.000000) * millimeter, vector(86.206900, -40.000000) * millimeter, vector(70.000000, 0.000000) * millimeter, vector(70.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(180.000000, 47.931050, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(180.000000, 47.931050, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0 (one_bend) ===
        // Flange 0->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-50.000000, 27.823850, 0.000000) * millimeter),
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
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(-50.0, 90.0, -50.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(0.000000, 140.000000) * millimeter, vector(80.000000, 140.000000) * millimeter, vector(89.352300, -40.000000) * millimeter, vector(89.352300, -48.000000) * millimeter, vector(86.538500, -48.000000) * millimeter, vector(86.538500, -52.000000) * millimeter, vector(-6.538500, -52.000000) * millimeter, vector(-6.538500, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(-50.000000, 27.823850, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2", EntityType.FACE), vector(-50.000000, 27.823850, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });