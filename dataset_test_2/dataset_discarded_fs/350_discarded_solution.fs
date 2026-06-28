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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 70.000000) * millimeter, vector(-2.055000, 100.000000) * millimeter, vector(-2.055000, 110.000000) * millimeter, vector(27.200000, 110.000000) * millimeter, vector(27.200000, 100.000000) * millimeter, vector(200.000000, 70.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter, vector(0.000000, 70.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(92.184400, 45.129721, 0.000000) * millimeter),
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
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(12.572500, 110.000000, 0.000000) * millimeter),
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
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(-170.0, 110.0, -30.0) * millimeter, vector(0.0, -1.0, 0.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-36.000000, -20.000000) * millimeter, vector(-36.000000, -32.000000) * millimeter, vector(-64.000000, -32.000000) * millimeter, vector(-64.000000, -20.000000) * millimeter, vector(-100.000000, 0.000000) * millimeter, vector(-167.945000, -20.000000) * millimeter, vector(-167.945000, -28.000000) * millimeter, vector(-197.200000, -28.000000) * millimeter, vector(-197.200000, -20.000000) * millimeter, vector(-100.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(12.572500, 110.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2", EntityType.FACE), vector(12.572500, 110.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 1 (two_bend) ===
        // Flange 1->1_1_3: bend=63.44deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-120.000000, -10.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 63.435205 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_1_3
        var wallFace1_1_3a = qClosestTo(qCreatedBy(id + "flange1_1_1_3a", EntityType.FACE), vector(-120.000000, -7.763952, -4.472146) * millimeter);
        var faceN1_1_3a = evPlane(context, { "face" : wallFace1_1_3a }).normal;
        var skN1_1_3a = dot(faceN1_1_3a, vector(0.0, -0.894429191, -0.4472095955)) >= 0 ? faceN1_1_3a : -faceN1_1_3a;
        var sketchRem1_1_3a = newSketchOnPlane(context, id + "sketchRem1_1_3a", { "sketchPlane" : plane(vector(-70.0, -5.5279, -8.9443) * millimeter, skN1_1_3a, vector(0.0, -0.4472095955, 0.894429191)) });
        skPolyline(sketchRem1_1_3a, "polyRem1_1_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000009, 0.000000) * millimeter, vector(8.000009, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-270.688819, 90.000000) * millimeter, vector(-278.688828, 90.000000) * millimeter, vector(-278.688828, 10.000000) * millimeter, vector(-270.688819, 10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_3a);
        sheetMetalTab(context, id + "smTab1_1_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_3a"), vector(-70.000000, -7.763952, -4.472146) * millimeter),
            "booleanUnionScope" : wallFace1_1_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_3->3: bend=63.44deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-120.000000, 120.000000, -260.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 63.435205 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_1_3_3b", EntityType.FACE), vector(-120.000000, 125.000000, -260.000000) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.0, 0.0, -1.0)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(-80.0, 130.0, -260.0) * millimeter, skN3b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(80.000000, -8.000000) * millimeter, vector(80.000000, 180.000000) * millimeter, vector(0.000000, 180.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(-120.000000, 130.000000, -260.000000) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });
    });