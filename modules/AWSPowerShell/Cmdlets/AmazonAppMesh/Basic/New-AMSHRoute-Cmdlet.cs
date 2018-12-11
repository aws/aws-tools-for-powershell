/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.AppMesh;
using Amazon.AppMesh.Model;

namespace Amazon.PowerShell.Cmdlets.AMSH
{
    /// <summary>
    /// Creates a new route that is associated with a virtual router.
    /// 
    ///          
    /// <para>
    /// You can use the <code>prefix</code> parameter in your route specification for path-based
    ///         routing of requests. For example, if your virtual router service name is 
    ///           <code>my-service.local</code>, and you want the route to match requests
    /// to            <code>my-service.local/metrics</code>, then your prefix should be  
    ///       <code>/metrics</code>.
    /// </para><para>
    /// If your route matches a request, you can distribute traffic to one or more target
    ///         virtual nodes with relative weighting.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AMSHRoute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppMesh.Model.RouteData")]
    [AWSCmdlet("Calls the AWS App Mesh CreateRoute API operation.", Operation = new[] {"CreateRoute"})]
    [AWSCmdletOutput("Amazon.AppMesh.Model.RouteData",
        "This cmdlet returns a RouteData object.",
        "The service call response (type Amazon.AppMesh.Model.CreateRouteResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMSHRouteCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of therequest.
        /// Up to 36 letters, numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh in which to create the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MeshName { get; set; }
        #endregion
        
        #region Parameter Match_Prefix
        /// <summary>
        /// <para>
        /// <para>Specifies the path with which to match requests. This parameter must always start
        /// with            <code>/</code>, which by itself matches all requests to the virtual
        /// router service name.         You can also match for path-based routing of requests.
        /// For example, if your virtual router         service name is <code>my-service.local</code>,
        /// and you want the route to match requests to            <code>my-service.local/metrics</code>,
        /// then your prefix should be         <code>/metrics</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Spec_HttpRoute_Match_Prefix")]
        public System.String Match_Prefix { get; set; }
        #endregion
        
        #region Parameter RouteName
        /// <summary>
        /// <para>
        /// <para>The name to use for the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RouteName { get; set; }
        #endregion
        
        #region Parameter VirtualRouterName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual router in which to create the route.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VirtualRouterName { get; set; }
        #endregion
        
        #region Parameter Action_WeightedTarget
        /// <summary>
        /// <para>
        /// <para>The targets that traffic is routed to when a request matches the route. You can specify
        ///         one or more targets and their relative weights with which to distribute traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Spec_HttpRoute_Action_WeightedTargets")]
        public Amazon.AppMesh.Model.WeightedTarget[] Action_WeightedTarget { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RouteName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMSHRoute (CreateRoute)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientToken = this.ClientToken;
            context.MeshName = this.MeshName;
            context.RouteName = this.RouteName;
            if (this.Action_WeightedTarget != null)
            {
                context.Spec_HttpRoute_Action_WeightedTargets = new List<Amazon.AppMesh.Model.WeightedTarget>(this.Action_WeightedTarget);
            }
            context.Spec_HttpRoute_Match_Prefix = this.Match_Prefix;
            context.VirtualRouterName = this.VirtualRouterName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AppMesh.Model.CreateRouteRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            if (cmdletContext.RouteName != null)
            {
                request.RouteName = cmdletContext.RouteName;
            }
            
             // populate Spec
            bool requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.RouteSpec();
            Amazon.AppMesh.Model.HttpRoute requestSpec_spec_HttpRoute = null;
            
             // populate HttpRoute
            bool requestSpec_spec_HttpRouteIsNull = true;
            requestSpec_spec_HttpRoute = new Amazon.AppMesh.Model.HttpRoute();
            Amazon.AppMesh.Model.HttpRouteAction requestSpec_spec_HttpRoute_spec_HttpRoute_Action = null;
            
             // populate Action
            bool requestSpec_spec_HttpRoute_spec_HttpRoute_ActionIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Action = new Amazon.AppMesh.Model.HttpRouteAction();
            List<Amazon.AppMesh.Model.WeightedTarget> requestSpec_spec_HttpRoute_spec_HttpRoute_Action_action_WeightedTarget = null;
            if (cmdletContext.Spec_HttpRoute_Action_WeightedTargets != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action_action_WeightedTarget = cmdletContext.Spec_HttpRoute_Action_WeightedTargets;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action_action_WeightedTarget != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action.WeightedTargets = requestSpec_spec_HttpRoute_spec_HttpRoute_Action_action_WeightedTarget;
                requestSpec_spec_HttpRoute_spec_HttpRoute_ActionIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Action should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_ActionIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Action = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Action != null)
            {
                requestSpec_spec_HttpRoute.Action = requestSpec_spec_HttpRoute_spec_HttpRoute_Action;
                requestSpec_spec_HttpRouteIsNull = false;
            }
            Amazon.AppMesh.Model.HttpRouteMatch requestSpec_spec_HttpRoute_spec_HttpRoute_Match = null;
            
             // populate Match
            bool requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = true;
            requestSpec_spec_HttpRoute_spec_HttpRoute_Match = new Amazon.AppMesh.Model.HttpRouteMatch();
            System.String requestSpec_spec_HttpRoute_spec_HttpRoute_Match_match_Prefix = null;
            if (cmdletContext.Spec_HttpRoute_Match_Prefix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match_match_Prefix = cmdletContext.Spec_HttpRoute_Match_Prefix;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match_match_Prefix != null)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match.Prefix = requestSpec_spec_HttpRoute_spec_HttpRoute_Match_match_Prefix;
                requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute_spec_HttpRoute_Match should be set to null
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_MatchIsNull)
            {
                requestSpec_spec_HttpRoute_spec_HttpRoute_Match = null;
            }
            if (requestSpec_spec_HttpRoute_spec_HttpRoute_Match != null)
            {
                requestSpec_spec_HttpRoute.Match = requestSpec_spec_HttpRoute_spec_HttpRoute_Match;
                requestSpec_spec_HttpRouteIsNull = false;
            }
             // determine if requestSpec_spec_HttpRoute should be set to null
            if (requestSpec_spec_HttpRouteIsNull)
            {
                requestSpec_spec_HttpRoute = null;
            }
            if (requestSpec_spec_HttpRoute != null)
            {
                request.Spec.HttpRoute = requestSpec_spec_HttpRoute;
                requestSpecIsNull = false;
            }
             // determine if request.Spec should be set to null
            if (requestSpecIsNull)
            {
                request.Spec = null;
            }
            if (cmdletContext.VirtualRouterName != null)
            {
                request.VirtualRouterName = cmdletContext.VirtualRouterName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Route;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AppMesh.Model.CreateRouteResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.CreateRouteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "CreateRoute");
            try
            {
                #if DESKTOP
                return client.CreateRoute(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateRouteAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.String MeshName { get; set; }
            public System.String RouteName { get; set; }
            public List<Amazon.AppMesh.Model.WeightedTarget> Spec_HttpRoute_Action_WeightedTargets { get; set; }
            public System.String Spec_HttpRoute_Match_Prefix { get; set; }
            public System.String VirtualRouterName { get; set; }
        }
        
    }
}
