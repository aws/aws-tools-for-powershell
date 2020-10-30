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
using Amazon.Braket;
using Amazon.Braket.Model;

namespace Amazon.PowerShell.Cmdlets.BRKT
{
    /// <summary>
    /// Creates a quantum task.
    /// </summary>
    [Cmdlet("New", "BRKTQuantumTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Braket CreateQuantumTask API operation.", Operation = new[] {"CreateQuantumTask"}, SelectReturnType = typeof(Amazon.Braket.Model.CreateQuantumTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.Braket.Model.CreateQuantumTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Braket.Model.CreateQuantumTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBRKTQuantumTaskCmdlet : AmazonBraketClientCmdlet, IExecutor
    {
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action associated with the task.</para>
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
        public System.String Action { get; set; }
        #endregion
        
        #region Parameter DeviceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the device to run the task on.</para>
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
        public System.String DeviceArn { get; set; }
        #endregion
        
        #region Parameter DeviceParameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the device to run the task on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceParameters")]
        public System.String DeviceParameter { get; set; }
        #endregion
        
        #region Parameter OutputS3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket to store task result files in.</para>
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
        public System.String OutputS3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The key prefix for the location in the S3 bucket to store task results in.</para>
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
        public System.String OutputS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Shot
        /// <summary>
        /// <para>
        /// <para>The number of shots to use for the task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Shots")]
        public System.Int64? Shot { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to be added to the quantum task you're creating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token associated with the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QuantumTaskArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Braket.Model.CreateQuantumTaskResponse).
        /// Specifying the name of a property of type Amazon.Braket.Model.CreateQuantumTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QuantumTaskArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeviceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BRKTQuantumTask (CreateQuantumTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Braket.Model.CreateQuantumTaskResponse, NewBRKTQuantumTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DeviceArn = this.DeviceArn;
            #if MODULAR
            if (this.DeviceArn == null && ParameterWasBound(nameof(this.DeviceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceParameter = this.DeviceParameter;
            context.OutputS3Bucket = this.OutputS3Bucket;
            #if MODULAR
            if (this.OutputS3Bucket == null && ParameterWasBound(nameof(this.OutputS3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputS3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputS3KeyPrefix = this.OutputS3KeyPrefix;
            #if MODULAR
            if (this.OutputS3KeyPrefix == null && ParameterWasBound(nameof(this.OutputS3KeyPrefix)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputS3KeyPrefix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Shot = this.Shot;
            #if MODULAR
            if (this.Shot == null && ParameterWasBound(nameof(this.Shot)))
            {
                WriteWarning("You are passing $null as a value for parameter Shot which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.Braket.Model.CreateQuantumTaskRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeviceArn != null)
            {
                request.DeviceArn = cmdletContext.DeviceArn;
            }
            if (cmdletContext.DeviceParameter != null)
            {
                request.DeviceParameters = cmdletContext.DeviceParameter;
            }
            if (cmdletContext.OutputS3Bucket != null)
            {
                request.OutputS3Bucket = cmdletContext.OutputS3Bucket;
            }
            if (cmdletContext.OutputS3KeyPrefix != null)
            {
                request.OutputS3KeyPrefix = cmdletContext.OutputS3KeyPrefix;
            }
            if (cmdletContext.Shot != null)
            {
                request.Shots = cmdletContext.Shot.Value;
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
        
        private Amazon.Braket.Model.CreateQuantumTaskResponse CallAWSServiceOperation(IAmazonBraket client, Amazon.Braket.Model.CreateQuantumTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Braket", "CreateQuantumTask");
            try
            {
                #if DESKTOP
                return client.CreateQuantumTask(request);
                #elif CORECLR
                return client.CreateQuantumTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String Action { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DeviceArn { get; set; }
            public System.String DeviceParameter { get; set; }
            public System.String OutputS3Bucket { get; set; }
            public System.String OutputS3KeyPrefix { get; set; }
            public System.Int64? Shot { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Braket.Model.CreateQuantumTaskResponse, NewBRKTQuantumTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QuantumTaskArn;
        }
        
    }
}
