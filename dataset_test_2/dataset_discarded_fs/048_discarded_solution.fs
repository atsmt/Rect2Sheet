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
        skPolyline(sketch0, "poly0", { "points" : [vector(-85.000000, 29.000000) * millimeter, vector(-190.000000, 29.000000) * millimeter, vector(-190.000000, 165.000000) * millimeter, vector(-85.000000, 165.000000) * millimeter, vector(-10.000000, 191.000000) * millimeter, vector(0.000000, 191.000000) * millimeter, vector(-3.863100, 223.000000) * millimeter, vector(-3.863100, 233.000000) * millimeter, vector(91.755200, 233.000000) * millimeter, vector(91.755200, 223.000000) * millimeter, vector(163.000000, 191.000000) * millimeter, vector(163.000000, 0.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(-85.000000, 29.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(4.884254, 104.968532, 0.000000) * millimeter),
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

        // === Child Tab 3 from 0 (one_bend) ===
        // Flange 0->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(43.946050, 233.000000, 0.000000) * millimeter),
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
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(-190.0, 233.0, -68.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(-269.720370, -45.498303) * millimeter, vector(-343.832200, -58.000000) * millimeter, vector(-343.832200, -70.000000) * millimeter, vector(-567.678800, -70.000000) * millimeter, vector(-567.678800, -58.000000) * millimeter, vector(-243.457331, -18.216440) * millimeter, vector(-95.000000, 136.000000) * millimeter, vector(0.000000, 136.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(-129.262630, -21.804917) * millimeter, vector(-186.136900, -58.000000) * millimeter, vector(-186.136900, -66.000000) * millimeter, vector(-281.755200, -66.000000) * millimeter, vector(-281.755200, -58.000000) * millimeter, vector(-269.720370, -45.498303) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(43.946050, 233.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_3", EntityType.FACE), vector(43.946050, 233.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });