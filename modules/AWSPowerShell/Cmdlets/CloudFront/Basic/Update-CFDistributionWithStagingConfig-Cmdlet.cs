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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Copies the staging distribution's configuration to its corresponding primary distribution.
    /// The primary distribution retains its <c>Aliases</c> (also known as alternate domain
    /// names or CNAMEs) and <c>ContinuousDeploymentPolicyId</c> value, but otherwise its
    /// configuration is overwritten to match the staging distribution.
    /// 
    ///  
    /// <para>
    /// You can use this operation in a continuous deployment workflow after you have tested
    /// configuration changes on the staging distribution. After using a continuous deployment
    /// policy to move a portion of your domain name's traffic to the staging distribution
    /// and verifying that it works as intended, you can use this operation to copy the staging
    /// distribution's configuration to the primary distribution. This action will disable
    /// the continuous deployment policy and move your domain's traffic back to the primary
    /// distribution.
    /// </para><para>
    /// This API operation requires the following IAM permissions:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_GetDistribution.html">GetDistribution</a></para></li><li><para><a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_UpdateDistribution.html">UpdateDistribution</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "CFDistributionWithStagingConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.Distribution")]
    [AWSCmdlet("Calls the Amazon CloudFront UpdateDistributionWithStagingConfig API operation.", Operation = new[] {"UpdateDistributionWithStagingConfig"}, SelectReturnType = typeof(Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.Distribution or Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.Distribution object.",
        "The service call response (type Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFDistributionWithStagingConfigCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the primary distribution to which you are copying a staging distribution's
        /// configuration.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The current versions (<c>ETag</c> values) of both primary and staging distributions.
        /// Provide these in the following format:</para><para><c>&lt;primary ETag&gt;, &lt;staging ETag&gt;</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter StagingDistributionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the staging distribution whose configuration you are copying to
        /// the primary distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StagingDistributionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Distribution'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Distribution";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFDistributionWithStagingConfig (UpdateDistributionWithStagingConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigResponse, UpdateCFDistributionWithStagingConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            context.StagingDistributionId = this.StagingDistributionId;
            
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
            var request = new Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            if (cmdletContext.StagingDistributionId != null)
            {
                request.StagingDistributionId = cmdletContext.StagingDistributionId;
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
        
        private Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "UpdateDistributionWithStagingConfig");
            try
            {
                #if DESKTOP
                return client.UpdateDistributionWithStagingConfig(request);
                #elif CORECLR
                return client.UpdateDistributionWithStagingConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.String StagingDistributionId { get; set; }
            public System.Func<Amazon.CloudFront.Model.UpdateDistributionWithStagingConfigResponse, UpdateCFDistributionWithStagingConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Distribution;
        }
        
    }
}
