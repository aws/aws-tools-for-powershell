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
using Amazon.ResilienceHub;
using Amazon.ResilienceHub.Model;

namespace Amazon.PowerShell.Cmdlets.RESH
{
    /// <summary>
    /// Adds the source of resource-maps to the draft version of an application. During assessment,
    /// Resilience Hub will use these resource-maps to resolve the latest physical ID for
    /// each resource in the application template. For more information about different types
    /// of resources supported by Resilience Hub and how to add them in your application,
    /// see <a href="https://docs.aws.amazon.com/resilience-hub/latest/userguide/how-app-manage.html">Step
    /// 2: How is your application managed?</a> in the Resilience Hub User Guide.
    /// </summary>
    [Cmdlet("Add", "RESHDraftAppVersionResourceMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse")]
    [AWSCmdlet("Calls the AWS Resilience Hub AddDraftAppVersionResourceMappings API operation.", Operation = new[] {"AddDraftAppVersionResourceMappings"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse object containing multiple properties."
    )]
    public partial class AddRESHDraftAppVersionResourceMappingCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the Resilience Hub application. The format for this
        /// ARN is: arn:<c>partition</c>:resiliencehub:<c>region</c>:<c>account</c>:app/<c>app-id</c>.
        /// For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">
        /// Amazon Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>
        /// guide.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter ResourceMapping
        /// <summary>
        /// <para>
        /// <para>Mappings used to map logical resources from the template to physical resources. You
        /// can use the mapping type <c>CFN_STACK</c> if the application template uses a logical
        /// stack name. Or you can map individual resources by using the mapping type <c>RESOURCE</c>.
        /// We recommend using the mapping type <c>CFN_STACK</c> if the application is backed
        /// by a CloudFormation stack.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ResourceMappings")]
        public Amazon.ResilienceHub.Model.ResourceMapping[] ResourceMapping { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-RESHDraftAppVersionResourceMapping (AddDraftAppVersionResourceMappings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse, AddRESHDraftAppVersionResourceMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppArn = this.AppArn;
            #if MODULAR
            if (this.AppArn == null && ParameterWasBound(nameof(this.AppArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceMapping != null)
            {
                context.ResourceMapping = new List<Amazon.ResilienceHub.Model.ResourceMapping>(this.ResourceMapping);
            }
            #if MODULAR
            if (this.ResourceMapping == null && ParameterWasBound(nameof(this.ResourceMapping)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceMapping which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.ResourceMapping != null)
            {
                request.ResourceMappings = cmdletContext.ResourceMapping;
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
        
        private Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "AddDraftAppVersionResourceMappings");
            try
            {
                #if DESKTOP
                return client.AddDraftAppVersionResourceMappings(request);
                #elif CORECLR
                return client.AddDraftAppVersionResourceMappingsAsync(request).GetAwaiter().GetResult();
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
            public System.String AppArn { get; set; }
            public List<Amazon.ResilienceHub.Model.ResourceMapping> ResourceMapping { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.AddDraftAppVersionResourceMappingsResponse, AddRESHDraftAppVersionResourceMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
