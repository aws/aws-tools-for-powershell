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
using System.Threading;
using Amazon.HealthLake;
using Amazon.HealthLake.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AHL
{
    /// <summary>
    /// Starts an asynchronous data transformation job that converts source files from Amazon
    /// Simple Storage Service (Amazon S3) and writes the output to Amazon S3 or AWS HealthLake.
    /// </summary>
    [Cmdlet("Start", "AHLDataTransformationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.HealthLake.Model.StartDataTransformationJobResponse")]
    [AWSCmdlet("Calls the Amazon HealthLake StartDataTransformationJob API operation.", Operation = new[] {"StartDataTransformationJob"}, SelectReturnType = typeof(Amazon.HealthLake.Model.StartDataTransformationJobResponse))]
    [AWSCmdletOutput("Amazon.HealthLake.Model.StartDataTransformationJobResponse",
        "This cmdlet returns an Amazon.HealthLake.Model.StartDataTransformationJobResponse object containing multiple properties."
    )]
    public partial class StartAHLDataTransformationJobCmdlet : AmazonHealthLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that AWS HealthLake assumes to read from and write to the specified Amazon S3 locations.</para>
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
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter DriftDetectionEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether drift detection is enabled for this job. When enabled, AWS HealthLake
        /// writes a drift report to the output Amazon S3 location alongside the converted files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DriftDetectionEnabled { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>A descriptive name for the data transformation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Configuration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS Key Management Service (AWS KMS) key identifier used to encrypt the transformation
        /// job output written to Amazon S3.</para>
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
        public System.String OutputDataConfig_S3Configuration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ProfileId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the data transformation profile to use for conversion.</para>
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
        public System.String ProfileId { get; set; }
        #endregion
        
        #region Parameter ProvenanceEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether FHIR R4 Provenance resource generation is enabled for this transformation
        /// job. When provenance is enabled, the service also generates related DocumentReference
        /// and Device resources. If you don't specify a value, the default is <c>true</c>. To
        /// disable provenance output, set this parameter to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ProvenanceEnabled { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI of the input data to transform.</para>
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
        public System.String InputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Configuration_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where AWS HealthLake writes the converted output files.</para>
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
        public System.String OutputDataConfig_S3Configuration_S3Uri { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_SourceFormat
        /// <summary>
        /// <para>
        /// <para>The format of the source data files (C-CDA or CSV).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.HealthLake.SourceFormat")]
        public Amazon.HealthLake.SourceFormat InputDataConfig_SourceFormat { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, the service ignores the request
        /// but does not return an error.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.HealthLake.Model.StartDataTransformationJobResponse).
        /// Specifying the name of a property of type Amazon.HealthLake.Model.StartDataTransformationJobResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.ProfileId),
                nameof(this.DataAccessRoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-AHLDataTransformationJob (StartDataTransformationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.HealthLake.Model.StartDataTransformationJobResponse, StartAHLDataTransformationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DriftDetectionEnabled = this.DriftDetectionEnabled;
            context.InputDataConfig_S3Uri = this.InputDataConfig_S3Uri;
            #if MODULAR
            if (this.InputDataConfig_S3Uri == null && ParameterWasBound(nameof(this.InputDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_SourceFormat = this.InputDataConfig_SourceFormat;
            context.JobName = this.JobName;
            context.OutputDataConfig_S3Configuration_KmsKeyId = this.OutputDataConfig_S3Configuration_KmsKeyId;
            #if MODULAR
            if (this.OutputDataConfig_S3Configuration_KmsKeyId == null && ParameterWasBound(nameof(this.OutputDataConfig_S3Configuration_KmsKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3Configuration_KmsKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputDataConfig_S3Configuration_S3Uri = this.OutputDataConfig_S3Configuration_S3Uri;
            #if MODULAR
            if (this.OutputDataConfig_S3Configuration_S3Uri == null && ParameterWasBound(nameof(this.OutputDataConfig_S3Configuration_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3Configuration_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProfileId = this.ProfileId;
            #if MODULAR
            if (this.ProfileId == null && ParameterWasBound(nameof(this.ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvenanceEnabled = this.ProvenanceEnabled;
            
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
            var request = new Amazon.HealthLake.Model.StartDataTransformationJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.DriftDetectionEnabled != null)
            {
                request.DriftDetectionEnabled = cmdletContext.DriftDetectionEnabled.Value;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.HealthLake.Model.TransformationInputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_S3Uri = null;
            if (cmdletContext.InputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_S3Uri = cmdletContext.InputDataConfig_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_S3Uri != null)
            {
                request.InputDataConfig.S3Uri = requestInputDataConfig_inputDataConfig_S3Uri;
                requestInputDataConfigIsNull = false;
            }
            Amazon.HealthLake.SourceFormat requestInputDataConfig_inputDataConfig_SourceFormat = null;
            if (cmdletContext.InputDataConfig_SourceFormat != null)
            {
                requestInputDataConfig_inputDataConfig_SourceFormat = cmdletContext.InputDataConfig_SourceFormat;
            }
            if (requestInputDataConfig_inputDataConfig_SourceFormat != null)
            {
                request.InputDataConfig.SourceFormat = requestInputDataConfig_inputDataConfig_SourceFormat;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.HealthLake.Model.TransformationOutputDataConfig();
            Amazon.HealthLake.Model.DataTransformationS3Configuration requestOutputDataConfig_outputDataConfig_S3Configuration = null;
            
             // populate S3Configuration
            var requestOutputDataConfig_outputDataConfig_S3ConfigurationIsNull = true;
            requestOutputDataConfig_outputDataConfig_S3Configuration = new Amazon.HealthLake.Model.DataTransformationS3Configuration();
            System.String requestOutputDataConfig_outputDataConfig_S3Configuration_outputDataConfig_S3Configuration_KmsKeyId = null;
            if (cmdletContext.OutputDataConfig_S3Configuration_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration_outputDataConfig_S3Configuration_KmsKeyId = cmdletContext.OutputDataConfig_S3Configuration_KmsKeyId;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Configuration_outputDataConfig_S3Configuration_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration.KmsKeyId = requestOutputDataConfig_outputDataConfig_S3Configuration_outputDataConfig_S3Configuration_KmsKeyId;
                requestOutputDataConfig_outputDataConfig_S3ConfigurationIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3Configuration_outputDataConfig_S3Configuration_S3Uri = null;
            if (cmdletContext.OutputDataConfig_S3Configuration_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration_outputDataConfig_S3Configuration_S3Uri = cmdletContext.OutputDataConfig_S3Configuration_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Configuration_outputDataConfig_S3Configuration_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration.S3Uri = requestOutputDataConfig_outputDataConfig_S3Configuration_outputDataConfig_S3Configuration_S3Uri;
                requestOutputDataConfig_outputDataConfig_S3ConfigurationIsNull = false;
            }
             // determine if requestOutputDataConfig_outputDataConfig_S3Configuration should be set to null
            if (requestOutputDataConfig_outputDataConfig_S3ConfigurationIsNull)
            {
                requestOutputDataConfig_outputDataConfig_S3Configuration = null;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Configuration != null)
            {
                request.OutputDataConfig.S3Configuration = requestOutputDataConfig_outputDataConfig_S3Configuration;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.ProfileId != null)
            {
                request.ProfileId = cmdletContext.ProfileId;
            }
            if (cmdletContext.ProvenanceEnabled != null)
            {
                request.ProvenanceEnabled = cmdletContext.ProvenanceEnabled.Value;
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
        
        private Amazon.HealthLake.Model.StartDataTransformationJobResponse CallAWSServiceOperation(IAmazonHealthLake client, Amazon.HealthLake.Model.StartDataTransformationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon HealthLake", "StartDataTransformationJob");
            try
            {
                return client.StartDataTransformationJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DataAccessRoleArn { get; set; }
            public System.Boolean? DriftDetectionEnabled { get; set; }
            public System.String InputDataConfig_S3Uri { get; set; }
            public Amazon.HealthLake.SourceFormat InputDataConfig_SourceFormat { get; set; }
            public System.String JobName { get; set; }
            public System.String OutputDataConfig_S3Configuration_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3Configuration_S3Uri { get; set; }
            public System.String ProfileId { get; set; }
            public System.Boolean? ProvenanceEnabled { get; set; }
            public System.Func<Amazon.HealthLake.Model.StartDataTransformationJobResponse, StartAHLDataTransformationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
