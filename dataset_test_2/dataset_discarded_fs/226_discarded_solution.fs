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
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(-10.000000, 4.000000) * millimeter, vector(-20.000000, 4.000000) * millimeter, vector(-20.000000, 93.846200) * millimeter, vector(-10.000000, 93.846200) * millimeter, vector(0.000000, 95.000000) * millimeter, vector(120.000000, 95.000000) * millimeter, vector(120.000000, 0.000000) * millimeter, vector(83.076900, -10.000000) * millimeter, vector(83.076900, -20.000000) * millimeter, vector(36.923100, -20.000000) * millimeter, vector(36.923100, -10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(-10.000000, 4.000000) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(51.221721, 42.683191, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0_0 (one_bend) ===
        // Flange 0_0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-20.000000, 48.923100, 0.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(-20.0, 20.0, -40.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(-29.538480, -12.000000) * millimeter, vector(-160.000000, -12.000000) * millimeter, vector(-160.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(16.000000, -30.000000) * millimeter, vector(16.000000, -38.000000) * millimeter, vector(-73.846200, -38.000000) * millimeter, vector(-73.846200, -30.000000) * millimeter, vector(-29.538480, -12.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(-20.000000, 48.923100, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_1", EntityType.FACE), vector(-20.000000, 48.923100, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0_0 (one_bend) ===
        // Flange 0_0->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(60.000000, -20.000000, 0.000000) * millimeter),
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
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(120.0, -20.0, -30.0) * millimeter, vector(0.0, 1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-36.923100, -20.000000) * millimeter, vector(-36.923100, -28.000000) * millimeter, vector(-83.076900, -28.000000) * millimeter, vector(-83.076900, -20.000000) * millimeter, vector(-120.000000, 0.000000) * millimeter, vector(-120.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(60.000000, -20.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_2", EntityType.FACE), vector(60.000000, -20.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });