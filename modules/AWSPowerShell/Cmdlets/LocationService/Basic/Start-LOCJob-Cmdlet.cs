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
using Amazon.LocationService;
using Amazon.LocationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// <c>StartJob</c> starts a new asynchronous bulk processing job. You specify the input
    /// data location in Amazon S3, the action to perform, and the output location where results
    /// are written.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/location/latest/developerguide/jobs-concepts.html">Job
    /// concepts</a> in the <i>Amazon Location Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "LOCJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.StartJobResponse")]
    [AWSCmdlet("Calls the Amazon Location Service StartJob API operation.", Operation = new[] {"StartJob"}, SelectReturnType = typeof(Amazon.LocationService.Model.StartJobResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.StartJobResponse",
        "This cmdlet returns an Amazon.LocationService.Model.StartJobResponse object containing multiple properties."
    )]
    public partial class StartLOCJobCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action to perform on the input data.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LocationService.JobAction")]
        public Amazon.LocationService.JobAction Action { get; set; }
        #endregion
        
        #region Parameter ActionOptions_ValidateAddress_AdditionalFeature
        /// <summary>
        /// <para>
        /// <para>A list of optional additional parameters that can be requested for each result.</para><para>Values:</para><ul><li><para><c>Position</c> - Return the position coordinates of the address if available.</para></li><li><para><c>CountrySpecificAttributes</c> - Return additional information about the address
        /// specific to the country of origin.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionOptions_ValidateAddress_AdditionalFeatures")]
        public System.String[] ActionOptions_ValidateAddress_AdditionalFeature { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon Location Service assumes
        /// during job processing. Amazon Location Service uses this role to access the input
        /// and output locations specified for the job.</para><note><para>The IAM role must be created in the same Amazon Web Services account where you plan
        /// to run your job.</para></note><para>For more information about configuring IAM roles for Amazon Location jobs, see <a href="https://docs.aws.amazon.com/location/latest/developerguide/configure-iam-role-policy-credentials.html">Configure
        /// IAM permissions</a> in the <i>Amazon Location Service Developer Guide</i>.</para>
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
        
        #region Parameter InputOptions_Format
        /// <summary>
        /// <para>
        /// <para>Input data format. Currently only <c>Parquet</c> is supported.</para><note><para>Input files have a limitation of 10gb per file, and 1gb per Parquet row-group within
        /// the file.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LocationService.JobInputFormat")]
        public Amazon.LocationService.JobInputFormat InputOptions_Format { get; set; }
        #endregion
        
        #region Parameter OutputOptions_Format
        /// <summary>
        /// <para>
        /// <para>Output data format. Currently only "Parquet" is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LocationService.JobOutputFormat")]
        public Amazon.LocationService.JobOutputFormat OutputOptions_Format { get; set; }
        #endregion
        
        #region Parameter InputOptions_Location
        /// <summary>
        /// <para>
        /// <para>S3 ARN or URI where input files are stored.</para><note><para>The Amazon S3 bucket must be created in the same Amazon Web Services region where
        /// you plan to run your job.</para></note>
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
        public System.String InputOptions_Location { get; set; }
        #endregion
        
        #region Parameter OutputOptions_Location
        /// <summary>
        /// <para>
        /// <para>S3 ARN or URI where output files will be written.</para><note><para>The Amazon S3 bucket must exist in the same Amazon Web Services region where you plan
        /// to run your job.</para></note>
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
        public System.String OutputOptions_Location { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>An optional name for the job resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags and corresponding values to be associated with the job.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.StartJobResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.StartJobResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExecutionRoleArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LOCJob (StartJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.StartJobResponse, StartLOCJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ActionOptions_ValidateAddress_AdditionalFeature != null)
            {
                context.ActionOptions_ValidateAddress_AdditionalFeature = new List<System.String>(this.ActionOptions_ValidateAddress_AdditionalFeature);
            }
            context.ClientToken = this.ClientToken;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputOptions_Format = this.InputOptions_Format;
            #if MODULAR
            if (this.InputOptions_Format == null && ParameterWasBound(nameof(this.InputOptions_Format)))
            {
                WriteWarning("You are passing $null as a value for parameter InputOptions_Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputOptions_Location = this.InputOptions_Location;
            #if MODULAR
            if (this.InputOptions_Location == null && ParameterWasBound(nameof(this.InputOptions_Location)))
            {
                WriteWarning("You are passing $null as a value for parameter InputOptions_Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.OutputOptions_Format = this.OutputOptions_Format;
            #if MODULAR
            if (this.OutputOptions_Format == null && ParameterWasBound(nameof(this.OutputOptions_Format)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputOptions_Format which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputOptions_Location = this.OutputOptions_Location;
            #if MODULAR
            if (this.OutputOptions_Location == null && ParameterWasBound(nameof(this.OutputOptions_Location)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputOptions_Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.StartJobRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            
             // populate ActionOptions
            var requestActionOptionsIsNull = true;
            request.ActionOptions = new Amazon.LocationService.Model.JobActionOptions();
            Amazon.LocationService.Model.ValidateAddressActionOptions requestActionOptions_actionOptions_ValidateAddress = null;
            
             // populate ValidateAddress
            var requestActionOptions_actionOptions_ValidateAddressIsNull = true;
            requestActionOptions_actionOptions_ValidateAddress = new Amazon.LocationService.Model.ValidateAddressActionOptions();
            List<System.String> requestActionOptions_actionOptions_ValidateAddress_actionOptions_ValidateAddress_AdditionalFeature = null;
            if (cmdletContext.ActionOptions_ValidateAddress_AdditionalFeature != null)
            {
                requestActionOptions_actionOptions_ValidateAddress_actionOptions_ValidateAddress_AdditionalFeature = cmdletContext.ActionOptions_ValidateAddress_AdditionalFeature;
            }
            if (requestActionOptions_actionOptions_ValidateAddress_actionOptions_ValidateAddress_AdditionalFeature != null)
            {
                requestActionOptions_actionOptions_ValidateAddress.AdditionalFeatures = requestActionOptions_actionOptions_ValidateAddress_actionOptions_ValidateAddress_AdditionalFeature;
                requestActionOptions_actionOptions_ValidateAddressIsNull = false;
            }
             // determine if requestActionOptions_actionOptions_ValidateAddress should be set to null
            if (requestActionOptions_actionOptions_ValidateAddressIsNull)
            {
                requestActionOptions_actionOptions_ValidateAddress = null;
            }
            if (requestActionOptions_actionOptions_ValidateAddress != null)
            {
                request.ActionOptions.ValidateAddress = requestActionOptions_actionOptions_ValidateAddress;
                requestActionOptionsIsNull = false;
            }
             // determine if request.ActionOptions should be set to null
            if (requestActionOptionsIsNull)
            {
                request.ActionOptions = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate InputOptions
            var requestInputOptionsIsNull = true;
            request.InputOptions = new Amazon.LocationService.Model.JobInputOptions();
            Amazon.LocationService.JobInputFormat requestInputOptions_inputOptions_Format = null;
            if (cmdletContext.InputOptions_Format != null)
            {
                requestInputOptions_inputOptions_Format = cmdletContext.InputOptions_Format;
            }
            if (requestInputOptions_inputOptions_Format != null)
            {
                request.InputOptions.Format = requestInputOptions_inputOptions_Format;
                requestInputOptionsIsNull = false;
            }
            System.String requestInputOptions_inputOptions_Location = null;
            if (cmdletContext.InputOptions_Location != null)
            {
                requestInputOptions_inputOptions_Location = cmdletContext.InputOptions_Location;
            }
            if (requestInputOptions_inputOptions_Location != null)
            {
                request.InputOptions.Location = requestInputOptions_inputOptions_Location;
                requestInputOptionsIsNull = false;
            }
             // determine if request.InputOptions should be set to null
            if (requestInputOptionsIsNull)
            {
                request.InputOptions = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputOptions
            var requestOutputOptionsIsNull = true;
            request.OutputOptions = new Amazon.LocationService.Model.JobOutputOptions();
            Amazon.LocationService.JobOutputFormat requestOutputOptions_outputOptions_Format = null;
            if (cmdletContext.OutputOptions_Format != null)
            {
                requestOutputOptions_outputOptions_Format = cmdletContext.OutputOptions_Format;
            }
            if (requestOutputOptions_outputOptions_Format != null)
            {
                request.OutputOptions.Format = requestOutputOptions_outputOptions_Format;
                requestOutputOptionsIsNull = false;
            }
            System.String requestOutputOptions_outputOptions_Location = null;
            if (cmdletContext.OutputOptions_Location != null)
            {
                requestOutputOptions_outputOptions_Location = cmdletContext.OutputOptions_Location;
            }
            if (requestOutputOptions_outputOptions_Location != null)
            {
                request.OutputOptions.Location = requestOutputOptions_outputOptions_Location;
                requestOutputOptionsIsNull = false;
            }
             // determine if request.OutputOptions should be set to null
            if (requestOutputOptionsIsNull)
            {
                request.OutputOptions = null;
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
        
        private Amazon.LocationService.Model.StartJobResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.StartJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "StartJob");
            try
            {
                return client.StartJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LocationService.JobAction Action { get; set; }
            public List<System.String> ActionOptions_ValidateAddress_AdditionalFeature { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public Amazon.LocationService.JobInputFormat InputOptions_Format { get; set; }
            public System.String InputOptions_Location { get; set; }
            public System.String Name { get; set; }
            public Amazon.LocationService.JobOutputFormat OutputOptions_Format { get; set; }
            public System.String OutputOptions_Location { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LocationService.Model.StartJobResponse, StartLOCJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
