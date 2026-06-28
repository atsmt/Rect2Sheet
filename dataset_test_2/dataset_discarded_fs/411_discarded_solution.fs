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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 200.000000) * millimeter, vector(0.000000, 420.000000) * millimeter, vector(100.000000, 420.000000) * millimeter, vector(100.000000, 380.000000) * millimeter, vector(140.000000, 376.606300) * millimeter, vector(150.000000, 376.606300) * millimeter, vector(150.000000, 329.310300) * millimeter, vector(140.000000, 329.310300) * millimeter, vector(100.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(62.785568, 311.652602, 0.000000) * millimeter),
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

        // === Child Tab 2 from 0 (one_bend) ===
        // Flange 0->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(150.000000, 268.275850, 0.000000) * millimeter),
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
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(150.0, 350.0, -20.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(48.275900, -10.000000) * millimeter, vector(48.275900, -18.000000) * millimeter, vector(115.172400, -18.000000) * millimeter, vector(115.172400, -10.000000) * millimeter, vector(100.000000, 0.000000) * millimeter, vector(100.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(-26.606300, -10.000000) * millimeter, vector(-26.606300, -22.000000) * millimeter, vector(20.689700, -22.000000) * millimeter, vector(20.689700, -10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(150.000000, 268.275850, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2", EntityType.FACE), vector(150.000000, 268.275850, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 1 (one_bend) ===
        // Flange 1->3: bend=100.30deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, 420.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 100.304781 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 3
        var wallFace3 = qClosestTo(qCreatedBy(id + "flange1_3", EntityType.FACE), vector(50.000000, 419.105578, 4.919351) * millimeter);
        var faceN3 = evPlane(context, { "face" : wallFace3 }).normal;
        var skN3 = dot(faceN3, vector(0.0, -0.9838701158, -0.1788843068)) >= 0 ? faceN3 : -faceN3;
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(0.0, 412.8446, 39.3548) * millimeter, skN3, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(0.000000, -38.000000) * millimeter, vector(100.000000, -38.000000) * millimeter, vector(100.000000, 139.999984) * millimeter, vector(0.000000, 139.999984) * millimeter, vector(0.000000, -38.000000) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(50.000000, 412.844628, 39.354805) * millimeter),
            "booleanUnionScope" : wallFace3,
            "booleanOffset" : 0.0 * millimeter
        });
    });