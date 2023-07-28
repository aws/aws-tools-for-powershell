/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a staging distribution using the configuration of the provided primary distribution.
    /// A staging distribution is a copy of an existing distribution (called the primary distribution)
    /// that you can use in a continuous deployment workflow.
    /// 
    ///  
    /// <para>
    /// After you create a staging distribution, you can use <code>UpdateDistribution</code>
    /// to modify the staging distribution's configuration. Then you can use <code>CreateContinuousDeploymentPolicy</code>
    /// to incrementally move traffic to the staging distribution.
    /// </para><para>
    /// This API operation requires the following IAM permissions:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_GetDistribution.html">GetDistribution</a></para></li><li><para><a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_CreateDistribution.html">CreateDistribution</a></para></li><li><para><a href="https://docs.aws.amazon.com/cloudfront/latest/APIReference/API_CopyDistribution.html">CopyDistribution</a></para></li></ul>
    /// </summary>
    [Cmdlet("Copy", "CFDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudFront.Model.CopyDistributionResponse")]
    [AWSCmdlet("Calls the Amazon CloudFront CopyDistribution API operation.", Operation = new[] {"CopyDistribution"}, SelectReturnType = typeof(Amazon.CloudFront.Model.CopyDistributionResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.CopyDistributionResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.CopyDistributionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CopyCFDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A value that uniquely identifies a request to create a resource. This helps to prevent
        /// CloudFront from creating a duplicate resource if you accidentally resubmit an identical
        /// request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>A Boolean flag to specify the state of the staging distribution when it's created.
        /// When you set this value to <code>True</code>, the staging distribution is enabled.
        /// When you set this value to <code>False</code>, the staging distribution is disabled.</para><para>If you omit this field, the default value is <code>True</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The version identifier of the primary distribution whose configuration you are copying.
        /// This is the <code>ETag</code> value returned in the response to <code>GetDistribution</code>
        /// and <code>GetDistributionConfig</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter PrimaryDistributionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the primary distribution whose configuration you are copying. To
        /// get a distribution ID, use <code>ListDistributions</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PrimaryDistributionId { get; set; }
        #endregion
        
        #region Parameter Staging
        /// <summary>
        /// <para>
        /// <para>The type of distribution that your primary distribution will be copied to. The only
        /// valid value is <code>True</code>, indicating that you are copying to a staging distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Staging { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.CopyDistributionResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.CopyDistributionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PrimaryDistributionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-CFDistribution (CopyDistribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.CopyDistributionResponse, CopyCFDistributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CallerReference = this.CallerReference;
            #if MODULAR
            if (this.CallerReference == null && ParameterWasBound(nameof(this.CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Enabled = this.Enabled;
            context.IfMatch = this.IfMatch;
            context.PrimaryDistributionId = this.PrimaryDistributionId;
            #if MODULAR
            if (this.PrimaryDistributionId == null && ParameterWasBound(nameof(this.PrimaryDistributionId)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryDistributionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Staging = this.Staging;
            
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
            var request = new Amazon.CloudFront.Model.CopyDistributionRequest();
            
            if (cmdletContext.CallerReference != null)
            {
                request.CallerReference = cmdletContext.CallerReference;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
            }
            if (cmdletContext.PrimaryDistributionId != null)
            {
                request.PrimaryDistributionId = cmdletContext.PrimaryDistributionId;
            }
            if (cmdletContext.Staging != null)
            {
                request.Staging = cmdletContext.Staging.Value;
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
        
        private Amazon.CloudFront.Model.CopyDistributionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.CopyDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "CopyDistribution");
            try
            {
                #if DESKTOP
                return client.CopyDistribution(request);
                #elif CORECLR
                return client.CopyDistributionAsync(request).GetAwaiter().GetResult();
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
            public System.String CallerReference { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String IfMatch { get; set; }
            public System.String PrimaryDistributionId { get; set; }
            public System.Boolean? Staging { get; set; }
            public System.Func<Amazon.CloudFront.Model.CopyDistributionResponse, CopyCFDistributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
