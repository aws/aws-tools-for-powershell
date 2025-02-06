/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.GreengrassV2;
using Amazon.GreengrassV2.Model;

namespace Amazon.PowerShell.Cmdlets.GGV2
{
    /// <summary>
    /// Retrieves a list of components that meet the component, version, and platform requirements
    /// of a deployment. Greengrass core devices call this operation when they receive a deployment
    /// to identify the components to install.
    /// 
    ///  
    /// <para>
    /// This operation identifies components that meet all dependency requirements for a deployment.
    /// If the requirements conflict, then this operation returns an error and the deployment
    /// fails. For example, this occurs if component <c>A</c> requires version <c>&gt;2.0.0</c>
    /// and component <c>B</c> requires version <c>&lt;2.0.0</c> of a component dependency.
    /// </para><para>
    /// When you specify the component candidates to resolve, IoT Greengrass compares each
    /// component's digest from the core device with the component's digest in the Amazon
    /// Web Services Cloud. If the digests don't match, then IoT Greengrass specifies to use
    /// the version from the Amazon Web Services Cloud.
    /// </para><important><para>
    /// To use this operation, you must use the data plane API endpoint and authenticate with
    /// an IoT device certificate. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/greengrass.html">IoT
    /// Greengrass endpoints and quotas</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Resolve", "GGV2ComponentCandidate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GreengrassV2.Model.ResolvedComponentVersion")]
    [AWSCmdlet("Calls the AWS GreengrassV2 ResolveComponentCandidates API operation.", Operation = new[] {"ResolveComponentCandidates"}, SelectReturnType = typeof(Amazon.GreengrassV2.Model.ResolveComponentCandidatesResponse))]
    [AWSCmdletOutput("Amazon.GreengrassV2.Model.ResolvedComponentVersion or Amazon.GreengrassV2.Model.ResolveComponentCandidatesResponse",
        "This cmdlet returns a collection of Amazon.GreengrassV2.Model.ResolvedComponentVersion objects.",
        "The service call response (type Amazon.GreengrassV2.Model.ResolveComponentCandidatesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ResolveGGV2ComponentCandidateCmdlet : AmazonGreengrassV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Platform_Attribute
        /// <summary>
        /// <para>
        /// <para>A dictionary of attributes for the platform. The IoT Greengrass Core software defines
        /// the <c>os</c> and <c>architecture</c> by default. You can specify additional platform
        /// attributes for a core device when you deploy the Greengrass nucleus component. For
        /// more information, see the <a href="https://docs.aws.amazon.com/greengrass/v2/developerguide/greengrass-nucleus-component.html">Greengrass
        /// nucleus component</a> in the <i>IoT Greengrass V2 Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Platform_Attributes")]
        public System.Collections.Hashtable Platform_Attribute { get; set; }
        #endregion
        
        #region Parameter ComponentCandidate
        /// <summary>
        /// <para>
        /// <para>The list of components to resolve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComponentCandidates")]
        public Amazon.GreengrassV2.Model.ComponentCandidate[] ComponentCandidate { get; set; }
        #endregion
        
        #region Parameter Platform_Name
        /// <summary>
        /// <para>
        /// <para>The friendly name of the platform. This name helps you identify the platform.</para><para>If you omit this parameter, IoT Greengrass creates a friendly name from the <c>os</c>
        /// and <c>architecture</c> of the platform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Platform_Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResolvedComponentVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GreengrassV2.Model.ResolveComponentCandidatesResponse).
        /// Specifying the name of a property of type Amazon.GreengrassV2.Model.ResolveComponentCandidatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResolvedComponentVersions";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Platform_Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Resolve-GGV2ComponentCandidate (ResolveComponentCandidates)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GreengrassV2.Model.ResolveComponentCandidatesResponse, ResolveGGV2ComponentCandidateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ComponentCandidate != null)
            {
                context.ComponentCandidate = new List<Amazon.GreengrassV2.Model.ComponentCandidate>(this.ComponentCandidate);
            }
            if (this.Platform_Attribute != null)
            {
                context.Platform_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Platform_Attribute.Keys)
                {
                    context.Platform_Attribute.Add((String)hashKey, (System.String)(this.Platform_Attribute[hashKey]));
                }
            }
            context.Platform_Name = this.Platform_Name;
            
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
            var request = new Amazon.GreengrassV2.Model.ResolveComponentCandidatesRequest();
            
            if (cmdletContext.ComponentCandidate != null)
            {
                request.ComponentCandidates = cmdletContext.ComponentCandidate;
            }
            
             // populate Platform
            var requestPlatformIsNull = true;
            request.Platform = new Amazon.GreengrassV2.Model.ComponentPlatform();
            Dictionary<System.String, System.String> requestPlatform_platform_Attribute = null;
            if (cmdletContext.Platform_Attribute != null)
            {
                requestPlatform_platform_Attribute = cmdletContext.Platform_Attribute;
            }
            if (requestPlatform_platform_Attribute != null)
            {
                request.Platform.Attributes = requestPlatform_platform_Attribute;
                requestPlatformIsNull = false;
            }
            System.String requestPlatform_platform_Name = null;
            if (cmdletContext.Platform_Name != null)
            {
                requestPlatform_platform_Name = cmdletContext.Platform_Name;
            }
            if (requestPlatform_platform_Name != null)
            {
                request.Platform.Name = requestPlatform_platform_Name;
                requestPlatformIsNull = false;
            }
             // determine if request.Platform should be set to null
            if (requestPlatformIsNull)
            {
                request.Platform = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.GreengrassV2.Model.ResolveComponentCandidatesResponse CallAWSServiceOperation(IAmazonGreengrassV2 client, Amazon.GreengrassV2.Model.ResolveComponentCandidatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS GreengrassV2", "ResolveComponentCandidates");
            try
            {
                #if DESKTOP
                return client.ResolveComponentCandidates(request);
                #elif CORECLR
                return client.ResolveComponentCandidatesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GreengrassV2.Model.ComponentCandidate> ComponentCandidate { get; set; }
            public Dictionary<System.String, System.String> Platform_Attribute { get; set; }
            public System.String Platform_Name { get; set; }
            public System.Func<Amazon.GreengrassV2.Model.ResolveComponentCandidatesResponse, ResolveGGV2ComponentCandidateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResolvedComponentVersions;
        }
        
    }
}
