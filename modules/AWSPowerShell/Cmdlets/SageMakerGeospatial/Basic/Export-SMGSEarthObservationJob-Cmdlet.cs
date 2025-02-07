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
using Amazon.SageMakerGeospatial;
using Amazon.SageMakerGeospatial.Model;

namespace Amazon.PowerShell.Cmdlets.SMGS
{
    /// <summary>
    /// Use this operation to export results of an Earth Observation job and optionally source
    /// images used as input to the EOJ to an Amazon S3 location.
    /// </summary>
    [Cmdlet("Export", "SMGSEarthObservationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse")]
    [AWSCmdlet("Calls the SageMaker Geospatial ExportEarthObservationJob API operation.", Operation = new[] {"ExportEarthObservationJob"}, SelectReturnType = typeof(Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse))]
    [AWSCmdletOutput("Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse",
        "This cmdlet returns an Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse object containing multiple properties."
    )]
    public partial class ExportSMGSEarthObservationJobCmdlet : AmazonSageMakerGeospatialClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The input Amazon Resource Name (ARN) of the Earth Observation job being exported.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that you specified for the job.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ExportSourceImage
        /// <summary>
        /// <para>
        /// <para>The source images provided to the Earth Observation job being exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportSourceImages")]
        public System.Boolean? ExportSourceImage { get; set; }
        #endregion
        
        #region Parameter S3Data_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service key ID for server-side encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputConfig_S3Data_KmsKeyId")]
        public System.String S3Data_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter S3Data_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URL to the Amazon S3 data input.</para>
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
        [Alias("OutputConfig_S3Data_S3Uri")]
        public System.String S3Data_S3Uri { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that guarantees that the call to this API is idempotent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-SMGSEarthObservationJob (ExportEarthObservationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse, ExportSMGSEarthObservationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExportSourceImage = this.ExportSourceImage;
            context.S3Data_KmsKeyId = this.S3Data_KmsKeyId;
            context.S3Data_S3Uri = this.S3Data_S3Uri;
            #if MODULAR
            if (this.S3Data_S3Uri == null && ParameterWasBound(nameof(this.S3Data_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Data_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.ExportSourceImage != null)
            {
                request.ExportSourceImages = cmdletContext.ExportSourceImage.Value;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.SageMakerGeospatial.Model.OutputConfigInput();
            Amazon.SageMakerGeospatial.Model.ExportS3DataInput requestOutputConfig_outputConfig_S3Data = null;
            
             // populate S3Data
            var requestOutputConfig_outputConfig_S3DataIsNull = true;
            requestOutputConfig_outputConfig_S3Data = new Amazon.SageMakerGeospatial.Model.ExportS3DataInput();
            System.String requestOutputConfig_outputConfig_S3Data_s3Data_KmsKeyId = null;
            if (cmdletContext.S3Data_KmsKeyId != null)
            {
                requestOutputConfig_outputConfig_S3Data_s3Data_KmsKeyId = cmdletContext.S3Data_KmsKeyId;
            }
            if (requestOutputConfig_outputConfig_S3Data_s3Data_KmsKeyId != null)
            {
                requestOutputConfig_outputConfig_S3Data.KmsKeyId = requestOutputConfig_outputConfig_S3Data_s3Data_KmsKeyId;
                requestOutputConfig_outputConfig_S3DataIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3Data_s3Data_S3Uri = null;
            if (cmdletContext.S3Data_S3Uri != null)
            {
                requestOutputConfig_outputConfig_S3Data_s3Data_S3Uri = cmdletContext.S3Data_S3Uri;
            }
            if (requestOutputConfig_outputConfig_S3Data_s3Data_S3Uri != null)
            {
                requestOutputConfig_outputConfig_S3Data.S3Uri = requestOutputConfig_outputConfig_S3Data_s3Data_S3Uri;
                requestOutputConfig_outputConfig_S3DataIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_S3Data should be set to null
            if (requestOutputConfig_outputConfig_S3DataIsNull)
            {
                requestOutputConfig_outputConfig_S3Data = null;
            }
            if (requestOutputConfig_outputConfig_S3Data != null)
            {
                request.OutputConfig.S3Data = requestOutputConfig_outputConfig_S3Data;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
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
        
        private Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse CallAWSServiceOperation(IAmazonSageMakerGeospatial client, Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Geospatial", "ExportEarthObservationJob");
            try
            {
                #if DESKTOP
                return client.ExportEarthObservationJob(request);
                #elif CORECLR
                return client.ExportEarthObservationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Boolean? ExportSourceImage { get; set; }
            public System.String S3Data_KmsKeyId { get; set; }
            public System.String S3Data_S3Uri { get; set; }
            public System.Func<Amazon.SageMakerGeospatial.Model.ExportEarthObservationJobResponse, ExportSMGSEarthObservationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
