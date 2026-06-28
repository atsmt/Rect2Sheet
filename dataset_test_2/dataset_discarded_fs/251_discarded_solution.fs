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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-67.000000, 1.828000) * millimeter, vector(-77.000000, 1.828000) * millimeter, vector(-77.000000, 155.790200) * millimeter, vector(-87.000000, 155.790200) * millimeter, vector(-204.000000, 0.000000) * millimeter, vector(-510.000000, 0.000000) * millimeter, vector(-510.000000, 357.000000) * millimeter, vector(-204.000000, 357.000000) * millimeter, vector(-87.000000, 201.817700) * millimeter, vector(-77.000000, 201.817700) * millimeter, vector(-77.000000, 236.844500) * millimeter, vector(-67.000000, 236.844500) * millimeter, vector(0.000000, 357.000000) * millimeter, vector(255.000000, 357.000000) * millimeter, vector(255.000000, -432.000000) * millimeter, vector(0.000000, -432.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(-50.350759, 54.737562, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-77.000000, 119.336250, 0.000000) * millimeter),
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

        // Remaining polygon for tab 3
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(-77.0, 332.0, -102.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(0.000000, 178.000000) * millimeter, vector(306.000000, 178.000000) * millimeter, vector(330.172000, -92.000000) * millimeter, vector(330.172000, -100.000000) * millimeter, vector(176.209800, -100.000000) * millimeter, vector(176.209800, -104.000000) * millimeter, vector(130.182300, -104.000000) * millimeter, vector(130.182300, -100.000000) * millimeter, vector(95.155500, -100.000000) * millimeter, vector(95.155500, -92.000000) * millimeter, vector(116.811300, -82.550697) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(-77.000000, 119.336250, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_3", EntityType.FACE), vector(-77.000000, 119.336250, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });