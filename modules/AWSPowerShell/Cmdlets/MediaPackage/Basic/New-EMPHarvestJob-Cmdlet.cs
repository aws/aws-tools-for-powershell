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
using Amazon.MediaPackage;
using Amazon.MediaPackage.Model;

namespace Amazon.PowerShell.Cmdlets.EMP
{
    /// <summary>
    /// Creates a new HarvestJob record.
    /// </summary>
    [Cmdlet("New", "EMPHarvestJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackage.Model.CreateHarvestJobResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage CreateHarvestJob API operation.", Operation = new[] {"CreateHarvestJob"}, SelectReturnType = typeof(Amazon.MediaPackage.Model.CreateHarvestJobResponse))]
    [AWSCmdletOutput("Amazon.MediaPackage.Model.CreateHarvestJobResponse",
        "This cmdlet returns an Amazon.MediaPackage.Model.CreateHarvestJobResponse object containing multiple properties."
    )]
    public partial class NewEMPHarvestJobCmdlet : AmazonMediaPackageClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Destination_BucketName
        /// <summary>
        /// <para>
        /// The name of an S3 bucket within which harvested
        /// content will be exported
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
        public System.String S3Destination_BucketName { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// The end of the time-window which will be harvested
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
        public System.String EndTime { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The ID of the HarvestJob. The ID must be unique within
        /// the regionand it cannot be changed after the HarvestJob is submitted
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
        
        #region Parameter S3Destination_ManifestKey
        /// <summary>
        /// <para>
        /// The key in the specified S3 bucket where the
        /// harvested top-level manifest will be placed.
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
        public System.String S3Destination_ManifestKey { get; set; }
        #endregion
        
        #region Parameter OriginEndpointId
        /// <summary>
        /// <para>
        /// The ID of the OriginEndpoint that the
        /// HarvestJob will harvest from.This cannot be changed after the HarvestJob is submitted.
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
        public System.String OriginEndpointId { get; set; }
        #endregion
        
        #region Parameter S3Destination_RoleArn
        /// <summary>
        /// <para>
        /// The IAM role used to write to the specified S3
        /// bucket
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
        public System.String S3Destination_RoleArn { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// The start of the time-window which will be harvested
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
        public System.String StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackage.Model.CreateHarvestJobResponse).
        /// Specifying the name of a property of type Amazon.MediaPackage.Model.CreateHarvestJobResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMPHarvestJob (CreateHarvestJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackage.Model.CreateHarvestJobResponse, NewEMPHarvestJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OriginEndpointId = this.OriginEndpointId;
            #if MODULAR
            if (this.OriginEndpointId == null && ParameterWasBound(nameof(this.OriginEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_BucketName = this.S3Destination_BucketName;
            #if MODULAR
            if (this.S3Destination_BucketName == null && ParameterWasBound(nameof(this.S3Destination_BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_ManifestKey = this.S3Destination_ManifestKey;
            #if MODULAR
            if (this.S3Destination_ManifestKey == null && ParameterWasBound(nameof(this.S3Destination_ManifestKey)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_ManifestKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Destination_RoleArn = this.S3Destination_RoleArn;
            #if MODULAR
            if (this.S3Destination_RoleArn == null && ParameterWasBound(nameof(this.S3Destination_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Destination_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaPackage.Model.CreateHarvestJobRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.OriginEndpointId != null)
            {
                request.OriginEndpointId = cmdletContext.OriginEndpointId;
            }
            
             // populate S3Destination
            var requestS3DestinationIsNull = true;
            request.S3Destination = new Amazon.MediaPackage.Model.S3Destination();
            System.String requestS3Destination_s3Destination_BucketName = null;
            if (cmdletContext.S3Destination_BucketName != null)
            {
                requestS3Destination_s3Destination_BucketName = cmdletContext.S3Destination_BucketName;
            }
            if (requestS3Destination_s3Destination_BucketName != null)
            {
                request.S3Destination.BucketName = requestS3Destination_s3Destination_BucketName;
                requestS3DestinationIsNull = false;
            }
            System.String requestS3Destination_s3Destination_ManifestKey = null;
            if (cmdletContext.S3Destination_ManifestKey != null)
            {
                requestS3Destination_s3Destination_ManifestKey = cmdletContext.S3Destination_ManifestKey;
            }
            if (requestS3Destination_s3Destination_ManifestKey != null)
            {
                request.S3Destination.ManifestKey = requestS3Destination_s3Destination_ManifestKey;
                requestS3DestinationIsNull = false;
            }
            System.String requestS3Destination_s3Destination_RoleArn = null;
            if (cmdletContext.S3Destination_RoleArn != null)
            {
                requestS3Destination_s3Destination_RoleArn = cmdletContext.S3Destination_RoleArn;
            }
            if (requestS3Destination_s3Destination_RoleArn != null)
            {
                request.S3Destination.RoleArn = requestS3Destination_s3Destination_RoleArn;
                requestS3DestinationIsNull = false;
            }
             // determine if request.S3Destination should be set to null
            if (requestS3DestinationIsNull)
            {
                request.S3Destination = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime;
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
        
        private Amazon.MediaPackage.Model.CreateHarvestJobResponse CallAWSServiceOperation(IAmazonMediaPackage client, Amazon.MediaPackage.Model.CreateHarvestJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage", "CreateHarvestJob");
            try
            {
                #if DESKTOP
                return client.CreateHarvestJob(request);
                #elif CORECLR
                return client.CreateHarvestJobAsync(request).GetAwaiter().GetResult();
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
            public System.String EndTime { get; set; }
            public System.String Id { get; set; }
            public System.String OriginEndpointId { get; set; }
            public System.String S3Destination_BucketName { get; set; }
            public System.String S3Destination_ManifestKey { get; set; }
            public System.String S3Destination_RoleArn { get; set; }
            public System.String StartTime { get; set; }
            public System.Func<Amazon.MediaPackage.Model.CreateHarvestJobResponse, NewEMPHarvestJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
