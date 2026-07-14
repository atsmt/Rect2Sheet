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
        skPolyline(sketch0_0, "poly0_0", { "points" : [vector(250.000000, 130.000000) * millimeter, vector(250.000000, 0.000000) * millimeter, vector(150.000000, 0.000000) * millimeter, vector(150.000000, 130.000000) * millimeter, vector(250.000000, 130.000000) * millimeter] });
        skSolve(sketch0_0);
        opExtractSurface(context, id + "surf0_0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0_0"), vector(200.000000, 65.000000, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(120.000000, 18.205900, 0.000000) * millimeter),
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
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(120.0, 110.0, 20.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 1.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(-91.794100, -14.000000) * millimeter, vector(-108.588200, -10.000000) * millimeter, vector(-80.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(20.000000, 158.000000) * millimeter, vector(20.000000, -2.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(2.000000, -10.000000) * millimeter, vector(2.000000, -22.000000) * millimeter, vector(-73.000000, -22.000000) * millimeter, vector(-73.000000, -10.000000) * millimeter, vector(-80.000000, 0.000000) * millimeter, vector(-75.000000, -10.000000) * millimeter, vector(-91.794100, -14.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(120.000000, 18.205900, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_1", EntityType.FACE), vector(120.000000, 18.205900, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0_0 (two_bend) ===
        // Flange 0_0->3_0_0_3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_0_3_0_0_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(40.000000, -10.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 3_0_0_3
        var sketchRem3_0_0_3a = newSketchOnPlane(context, id + "sketchRem3_0_0_3a", { "sketchPlane" : plane(vector(0.0, -10.0, 10.0) * millimeter, vector(0.0, -1.0, 0.0), vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem3_0_0_3a, "polyRem3_0_0_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 80.000000) * millimeter, vector(0.000000, 80.000000) * millimeter, vector(-110.000000, -20.000000) * millimeter, vector(-108.000000, -30.000000) * millimeter, vector(-38.000000, -30.000000) * millimeter, vector(-40.000000, -20.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3_0_0_3a);
        sheetMetalTab(context, id + "smTab3_0_0_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3_0_0_3a"), vector(40.000000, -10.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_0_3_0_0_3a", EntityType.FACE), vector(40.000000, -10.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 3_0_0_3->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange3_0_0_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0_0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-30.000000, -10.000000, 85.000000) * millimeter),
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
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(-30.0, 0.0, 50.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(-120.000000, 0.000000) * millimeter, vector(-120.000000, 70.000000) * millimeter, vector(8.000000, 70.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(-120.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(-30.000000, -5.000000, 85.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange3_0_0_3_3b", EntityType.FACE), vector(-30.000000, -5.000000, 85.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });