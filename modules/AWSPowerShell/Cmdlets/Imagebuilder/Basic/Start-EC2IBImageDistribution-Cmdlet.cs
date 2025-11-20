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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// DistributeImage distributes existing AMIs to additional regions and accounts without
    /// rebuilding the image.
    /// </summary>
    [Cmdlet("Start", "EC2IBImageDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder DistributeImage API operation.", Operation = new[] {"DistributeImage"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.DistributeImageResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.DistributeImageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.DistributeImageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartEC2IBImageDistributionCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DistributionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the distribution configuration to use.</para>
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
        public System.String DistributionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The IAM role to use for the distribution.</para>
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
        public System.String ExecutionRole { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The log group name that Image Builder uses for image creation. If not specified, the
        /// log group name defaults to <c>/aws/imagebuilder/image-name</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_LogGroupName { get; set; }
        #endregion
        
        #region Parameter SourceImage
        /// <summary>
        /// <para>
        /// <para>The source image Amazon Resource Name (ARN) to distribute.</para>
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
        public System.String SourceImage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the distributed image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageBuildVersionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.DistributeImageResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.DistributeImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageBuildVersionArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DistributionConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EC2IBImageDistribution (DistributeImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.DistributeImageResponse, StartEC2IBImageDistributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DistributionConfigurationArn = this.DistributionConfigurationArn;
            #if MODULAR
            if (this.DistributionConfigurationArn == null && ParameterWasBound(nameof(this.DistributionConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionRole = this.ExecutionRole;
            #if MODULAR
            if (this.ExecutionRole == null && ParameterWasBound(nameof(this.ExecutionRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggingConfiguration_LogGroupName = this.LoggingConfiguration_LogGroupName;
            context.SourceImage = this.SourceImage;
            #if MODULAR
            if (this.SourceImage == null && ParameterWasBound(nameof(this.SourceImage)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceImage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.Imagebuilder.Model.DistributeImageRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DistributionConfigurationArn != null)
            {
                request.DistributionConfigurationArn = cmdletContext.DistributionConfigurationArn;
            }
            if (cmdletContext.ExecutionRole != null)
            {
                request.ExecutionRole = cmdletContext.ExecutionRole;
            }
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.Imagebuilder.Model.ImageLoggingConfiguration();
            System.String requestLoggingConfiguration_loggingConfiguration_LogGroupName = null;
            if (cmdletContext.LoggingConfiguration_LogGroupName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_LogGroupName = cmdletContext.LoggingConfiguration_LogGroupName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_LogGroupName != null)
            {
                request.LoggingConfiguration.LogGroupName = requestLoggingConfiguration_loggingConfiguration_LogGroupName;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            if (cmdletContext.SourceImage != null)
            {
                request.SourceImage = cmdletContext.SourceImage;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Imagebuilder.Model.DistributeImageResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.DistributeImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "DistributeImage");
            try
            {
                #if DESKTOP
                return client.DistributeImage(request);
                #elif CORECLR
                return client.DistributeImageAsync(request).GetAwaiter().GetResult();
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
            public System.String DistributionConfigurationArn { get; set; }
            public System.String ExecutionRole { get; set; }
            public System.String LoggingConfiguration_LogGroupName { get; set; }
            public System.String SourceImage { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.DistributeImageResponse, StartEC2IBImageDistributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageBuildVersionArn;
        }
        
    }
}
