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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// <note><para>
    /// This operation is not supported by directory buckets.
    /// </para></note><para>
    /// Replaces configuration for an Object Lambda Access Point.
    /// </para><para>
    /// The following actions are related to <c>PutAccessPointConfigurationForObjectLambda</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_GetAccessPointConfigurationForObjectLambda.html">GetAccessPointConfigurationForObjectLambda</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Write", "S3CAccessPointConfigurationForObjectLambda", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control PutAccessPointConfigurationForObjectLambda API operation.", Operation = new[] {"PutAccessPointConfigurationForObjectLambda"}, SelectReturnType = typeof(Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3CAccessPointConfigurationForObjectLambdaCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID for the account that owns the specified Object Lambda Access Point.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Configuration_AllowedFeature
        /// <summary>
        /// <para>
        /// <para>A container for allowed features. Valid inputs are <c>GetObject-Range</c>, <c>GetObject-PartNumber</c>,
        /// <c>HeadObject-Range</c>, and <c>HeadObject-PartNumber</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AllowedFeatures")]
        public System.String[] Configuration_AllowedFeature { get; set; }
        #endregion
        
        #region Parameter Configuration_CloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>A container for whether the CloudWatch metrics configuration is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_CloudWatchMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Object Lambda Access Point.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Configuration_SupportingAccessPoint
        /// <summary>
        /// <para>
        /// <para>Standard access point associated with the Object Lambda Access Point.</para>
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
        public System.String Configuration_SupportingAccessPoint { get; set; }
        #endregion
        
        #region Parameter Configuration_TransformationConfiguration
        /// <summary>
        /// <para>
        /// <para>A container for transformation configurations for an Object Lambda Access Point.</para>
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
        [Alias("Configuration_TransformationConfigurations")]
        public Amazon.S3Control.Model.ObjectLambdaTransformationConfiguration[] Configuration_TransformationConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaResponse).
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
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3CAccessPointConfigurationForObjectLambda (PutAccessPointConfigurationForObjectLambda)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaResponse, WriteS3CAccessPointConfigurationForObjectLambdaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Configuration_AllowedFeature != null)
            {
                context.Configuration_AllowedFeature = new List<System.String>(this.Configuration_AllowedFeature);
            }
            context.Configuration_CloudWatchMetricsEnabled = this.Configuration_CloudWatchMetricsEnabled;
            context.Configuration_SupportingAccessPoint = this.Configuration_SupportingAccessPoint;
            #if MODULAR
            if (this.Configuration_SupportingAccessPoint == null && ParameterWasBound(nameof(this.Configuration_SupportingAccessPoint)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_SupportingAccessPoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Configuration_TransformationConfiguration != null)
            {
                context.Configuration_TransformationConfiguration = new List<Amazon.S3Control.Model.ObjectLambdaTransformationConfiguration>(this.Configuration_TransformationConfiguration);
            }
            #if MODULAR
            if (this.Configuration_TransformationConfiguration == null && ParameterWasBound(nameof(this.Configuration_TransformationConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_TransformationConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.S3Control.Model.ObjectLambdaConfiguration();
            List<System.String> requestConfiguration_configuration_AllowedFeature = null;
            if (cmdletContext.Configuration_AllowedFeature != null)
            {
                requestConfiguration_configuration_AllowedFeature = cmdletContext.Configuration_AllowedFeature;
            }
            if (requestConfiguration_configuration_AllowedFeature != null)
            {
                request.Configuration.AllowedFeatures = requestConfiguration_configuration_AllowedFeature;
                requestConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_CloudWatchMetricsEnabled = null;
            if (cmdletContext.Configuration_CloudWatchMetricsEnabled != null)
            {
                requestConfiguration_configuration_CloudWatchMetricsEnabled = cmdletContext.Configuration_CloudWatchMetricsEnabled.Value;
            }
            if (requestConfiguration_configuration_CloudWatchMetricsEnabled != null)
            {
                request.Configuration.CloudWatchMetricsEnabled = requestConfiguration_configuration_CloudWatchMetricsEnabled.Value;
                requestConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_SupportingAccessPoint = null;
            if (cmdletContext.Configuration_SupportingAccessPoint != null)
            {
                requestConfiguration_configuration_SupportingAccessPoint = cmdletContext.Configuration_SupportingAccessPoint;
            }
            if (requestConfiguration_configuration_SupportingAccessPoint != null)
            {
                request.Configuration.SupportingAccessPoint = requestConfiguration_configuration_SupportingAccessPoint;
                requestConfigurationIsNull = false;
            }
            List<Amazon.S3Control.Model.ObjectLambdaTransformationConfiguration> requestConfiguration_configuration_TransformationConfiguration = null;
            if (cmdletContext.Configuration_TransformationConfiguration != null)
            {
                requestConfiguration_configuration_TransformationConfiguration = cmdletContext.Configuration_TransformationConfiguration;
            }
            if (requestConfiguration_configuration_TransformationConfiguration != null)
            {
                request.Configuration.TransformationConfigurations = requestConfiguration_configuration_TransformationConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "PutAccessPointConfigurationForObjectLambda");
            try
            {
                #if DESKTOP
                return client.PutAccessPointConfigurationForObjectLambda(request);
                #elif CORECLR
                return client.PutAccessPointConfigurationForObjectLambdaAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public List<System.String> Configuration_AllowedFeature { get; set; }
            public System.Boolean? Configuration_CloudWatchMetricsEnabled { get; set; }
            public System.String Configuration_SupportingAccessPoint { get; set; }
            public List<Amazon.S3Control.Model.ObjectLambdaTransformationConfiguration> Configuration_TransformationConfiguration { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.S3Control.Model.PutAccessPointConfigurationForObjectLambdaResponse, WriteS3CAccessPointConfigurationForObjectLambdaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
