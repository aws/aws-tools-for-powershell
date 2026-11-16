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
using Amazon.ConnectHealth;
using Amazon.ConnectHealth.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CNH
{
    /// <summary>
    /// Creates a Dataset in a Domain and starts building it. A new dataset has the status
    /// CREATING. When it's ready to use, its status changes to ACTIVE, or to CREATE_FAILED
    /// if it fails to build. To check the status, call GetDataset.
    /// 
    ///  
    /// <para>
    /// This operation is idempotent: if you retry a request with the same clientToken, it
    /// returns the dataset that the first request created.
    /// </para><para>
    /// For a medical coding dataset, Amazon Connect Health uses the coded examples that are
    /// in the s3InputPath when you create the dataset, and writes evaluation scores to the
    /// s3OutputPath. Later changes to the s3InputPath don't change the dataset. To use this
    /// operation, you must have s3:GetObject and s3:ListBucket permissions for the input
    /// location and s3:PutObject permission for the output location, and kms:Decrypt and
    /// kms:GenerateDataKey permissions if you encrypt the locations with an AWS KMS key.
    /// </para><para>
    /// Datasets are in preview release and are subject to change.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CNHDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectHealth.Model.CreateDatasetResponse")]
    [AWSCmdlet("Calls the Connect Health CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.ConnectHealth.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("Amazon.ConnectHealth.Model.CreateDatasetResponse",
        "This cmdlet returns an Amazon.ConnectHealth.Model.CreateDatasetResponse object containing multiple properties."
    )]
    public partial class NewCNHDatasetCmdlet : AmazonConnectHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the parent Domain.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the dataset.</para>
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
        
        #region Parameter Config_MedicalCoding_S3InputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location of your coded examples. You need s3:GetObject and s3:ListBucket
        /// permissions for it, and kms:Decrypt if you encrypt it with an AWS KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Config_MedicalCoding_S3InputPath { get; set; }
        #endregion
        
        #region Parameter Config_MedicalCoding_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location where Amazon Connect Health writes the evaluation scores for
        /// the dataset. You need s3:PutObject permission for it, and kms:GenerateDataKey if you
        /// encrypt it with an AWS KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Config_MedicalCoding_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, the operation returns the
        /// dataset that the first request created. If you reuse a clientToken with different
        /// parameters, the request fails with ConflictException. Use a new clientToken for a
        /// request with different parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectHealth.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.ConnectHealth.Model.CreateDatasetResponse will result in that property being returned.
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
                nameof(this.DomainId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CNHDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectHealth.Model.CreateDatasetResponse, NewCNHDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Config_MedicalCoding_S3InputPath = this.Config_MedicalCoding_S3InputPath;
            context.Config_MedicalCoding_S3OutputPath = this.Config_MedicalCoding_S3OutputPath;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectHealth.Model.CreateDatasetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Config
            var requestConfigIsNull = true;
            request.Config = new Amazon.ConnectHealth.Model.DatasetConfig();
            Amazon.ConnectHealth.Model.MedicalCodingDatasetConfig requestConfig_config_MedicalCoding = null;
            
             // populate MedicalCoding
            var requestConfig_config_MedicalCodingIsNull = true;
            requestConfig_config_MedicalCoding = new Amazon.ConnectHealth.Model.MedicalCodingDatasetConfig();
            System.String requestConfig_config_MedicalCoding_config_MedicalCoding_S3InputPath = null;
            if (cmdletContext.Config_MedicalCoding_S3InputPath != null)
            {
                requestConfig_config_MedicalCoding_config_MedicalCoding_S3InputPath = cmdletContext.Config_MedicalCoding_S3InputPath;
            }
            if (requestConfig_config_MedicalCoding_config_MedicalCoding_S3InputPath != null)
            {
                requestConfig_config_MedicalCoding.S3InputPath = requestConfig_config_MedicalCoding_config_MedicalCoding_S3InputPath;
                requestConfig_config_MedicalCodingIsNull = false;
            }
            System.String requestConfig_config_MedicalCoding_config_MedicalCoding_S3OutputPath = null;
            if (cmdletContext.Config_MedicalCoding_S3OutputPath != null)
            {
                requestConfig_config_MedicalCoding_config_MedicalCoding_S3OutputPath = cmdletContext.Config_MedicalCoding_S3OutputPath;
            }
            if (requestConfig_config_MedicalCoding_config_MedicalCoding_S3OutputPath != null)
            {
                requestConfig_config_MedicalCoding.S3OutputPath = requestConfig_config_MedicalCoding_config_MedicalCoding_S3OutputPath;
                requestConfig_config_MedicalCodingIsNull = false;
            }
             // determine if requestConfig_config_MedicalCoding should be set to null
            if (requestConfig_config_MedicalCodingIsNull)
            {
                requestConfig_config_MedicalCoding = null;
            }
            if (requestConfig_config_MedicalCoding != null)
            {
                request.Config.MedicalCoding = requestConfig_config_MedicalCoding;
                requestConfigIsNull = false;
            }
             // determine if request.Config should be set to null
            if (requestConfigIsNull)
            {
                request.Config = null;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
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
        
        private Amazon.ConnectHealth.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonConnectHealth client, Amazon.ConnectHealth.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Connect Health", "CreateDataset");
            try
            {
                return client.CreateDatasetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Config_MedicalCoding_S3InputPath { get; set; }
            public System.String Config_MedicalCoding_S3OutputPath { get; set; }
            public System.String DomainId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.ConnectHealth.Model.CreateDatasetResponse, NewCNHDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
