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
        skPolyline(sketch0, "poly0", { "points" : [vector(408.000000, 32.000000) * millimeter, vector(278.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(0.000000, 167.000000) * millimeter, vector(278.000000, 167.000000) * millimeter, vector(408.000000, 149.000000) * millimeter, vector(686.000000, 149.000000) * millimeter, vector(690.858900, 32.202100) * millimeter, vector(691.274600, 22.210800) * millimeter, vector(418.878700, 10.878800) * millimeter, vector(418.463000, 20.870100) * millimeter, vector(686.000000, 32.000000) * millimeter, vector(408.000000, 32.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(320.789442, 84.655575, 0.000000) * millimeter),
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

        // === Child Tab 1 from 2 (one_bend) ===
        // Flange 2->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-83.000000, -10.000000, 167.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(-83.0, 167.0, 33.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(179.000000, 0.000000) * millimeter, vector(179.000000, 268.000000) * millimeter, vector(0.000000, 268.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(-83.000000, -5.000000, 167.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange2_1", EntityType.FACE), vector(-83.000000, -5.000000, 167.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });