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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates an Amazon FPGA Image (AFI) from the specified design checkpoint (DCP).
    /// 
    ///  
    /// <para>
    /// The create operation is asynchronous. To verify that the AFI is ready for use, check
    /// the output logs.
    /// </para><para>
    /// An AFI contains the FPGA bitstream that is ready to download to an FPGA. You can securely
    /// deploy an AFI on multiple FPGA-accelerated instances. For more information, see the
    /// <a href="https://github.com/aws/aws-fpga/">Amazon Web Services FPGA Hardware Development
    /// Kit</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2FpgaImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateFpgaImageResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateFpgaImage API operation.", Operation = new[] {"CreateFpgaImage"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateFpgaImageResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateFpgaImageResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateFpgaImageResponse object containing multiple properties."
    )]
    public partial class NewEC2FpgaImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InputStorageLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputStorageLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter LogsStorageLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogsStorageLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the AFI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter InputStorageLocation_Key
        /// <summary>
        /// <para>
        /// <para>The key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputStorageLocation_Key { get; set; }
        #endregion
        
        #region Parameter LogsStorageLocation_Key
        /// <summary>
        /// <para>
        /// <para>The key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogsStorageLocation_Key { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the AFI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the FPGA image during creation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateFpgaImageResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateFpgaImageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2FpgaImage (CreateFpgaImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateFpgaImageResponse, NewEC2FpgaImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.InputStorageLocation_Bucket = this.InputStorageLocation_Bucket;
            context.InputStorageLocation_Key = this.InputStorageLocation_Key;
            context.LogsStorageLocation_Bucket = this.LogsStorageLocation_Bucket;
            context.LogsStorageLocation_Key = this.LogsStorageLocation_Key;
            context.Name = this.Name;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateFpgaImageRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate InputStorageLocation
            var requestInputStorageLocationIsNull = true;
            request.InputStorageLocation = new Amazon.EC2.Model.StorageLocation();
            System.String requestInputStorageLocation_inputStorageLocation_Bucket = null;
            if (cmdletContext.InputStorageLocation_Bucket != null)
            {
                requestInputStorageLocation_inputStorageLocation_Bucket = cmdletContext.InputStorageLocation_Bucket;
            }
            if (requestInputStorageLocation_inputStorageLocation_Bucket != null)
            {
                request.InputStorageLocation.Bucket = requestInputStorageLocation_inputStorageLocation_Bucket;
                requestInputStorageLocationIsNull = false;
            }
            System.String requestInputStorageLocation_inputStorageLocation_Key = null;
            if (cmdletContext.InputStorageLocation_Key != null)
            {
                requestInputStorageLocation_inputStorageLocation_Key = cmdletContext.InputStorageLocation_Key;
            }
            if (requestInputStorageLocation_inputStorageLocation_Key != null)
            {
                request.InputStorageLocation.Key = requestInputStorageLocation_inputStorageLocation_Key;
                requestInputStorageLocationIsNull = false;
            }
             // determine if request.InputStorageLocation should be set to null
            if (requestInputStorageLocationIsNull)
            {
                request.InputStorageLocation = null;
            }
            
             // populate LogsStorageLocation
            var requestLogsStorageLocationIsNull = true;
            request.LogsStorageLocation = new Amazon.EC2.Model.StorageLocation();
            System.String requestLogsStorageLocation_logsStorageLocation_Bucket = null;
            if (cmdletContext.LogsStorageLocation_Bucket != null)
            {
                requestLogsStorageLocation_logsStorageLocation_Bucket = cmdletContext.LogsStorageLocation_Bucket;
            }
            if (requestLogsStorageLocation_logsStorageLocation_Bucket != null)
            {
                request.LogsStorageLocation.Bucket = requestLogsStorageLocation_logsStorageLocation_Bucket;
                requestLogsStorageLocationIsNull = false;
            }
            System.String requestLogsStorageLocation_logsStorageLocation_Key = null;
            if (cmdletContext.LogsStorageLocation_Key != null)
            {
                requestLogsStorageLocation_logsStorageLocation_Key = cmdletContext.LogsStorageLocation_Key;
            }
            if (requestLogsStorageLocation_logsStorageLocation_Key != null)
            {
                request.LogsStorageLocation.Key = requestLogsStorageLocation_logsStorageLocation_Key;
                requestLogsStorageLocationIsNull = false;
            }
             // determine if request.LogsStorageLocation should be set to null
            if (requestLogsStorageLocationIsNull)
            {
                request.LogsStorageLocation = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateFpgaImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateFpgaImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateFpgaImage");
            try
            {
                return client.CreateFpgaImageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String InputStorageLocation_Bucket { get; set; }
            public System.String InputStorageLocation_Key { get; set; }
            public System.String LogsStorageLocation_Bucket { get; set; }
            public System.String LogsStorageLocation_Key { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateFpgaImageResponse, NewEC2FpgaImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
