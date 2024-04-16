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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Creates a gateway task definition.
    /// </summary>
    [Cmdlet("New", "IOTWWirelessGatewayTaskDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT Wireless CreateWirelessGatewayTaskDefinition API operation.", Operation = new[] {"CreateWirelessGatewayTaskDefinition"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTWWirelessGatewayTaskDefinitionCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoCreateTask
        /// <summary>
        /// <para>
        /// <para>Whether to automatically create tasks using this task definition for all gateways
        /// with the specified current version. If <c>false</c>, the task must me created by calling
        /// <c>CreateWirelessGatewayTask</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AutoCreateTasks")]
        public System.Boolean? AutoCreateTask { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Each resource must have a unique client request token. The client token is used to
        /// implement idempotency. It ensures that the request completes no more than one time.
        /// If you retry a request with the same token and the same parameters, the request will
        /// complete successfully. However, if you try to create a new resource using the same
        /// token but different parameters, an HTTP 409 conflict occurs. If you omit this value,
        /// AWS SDKs will automatically generate a unique client request. For more information
        /// about idempotency, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency in Amazon EC2 API requests</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CurrentVersion_Model
        /// <summary>
        /// <para>
        /// <para>The model number of the wireless gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_LoRaWAN_CurrentVersion_Model")]
        public System.String CurrentVersion_Model { get; set; }
        #endregion
        
        #region Parameter UpdateVersion_Model
        /// <summary>
        /// <para>
        /// <para>The model number of the wireless gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_LoRaWAN_UpdateVersion_Model")]
        public System.String UpdateVersion_Model { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CurrentVersion_PackageVersion
        /// <summary>
        /// <para>
        /// <para>The version of the wireless gateway firmware.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_LoRaWAN_CurrentVersion_PackageVersion")]
        public System.String CurrentVersion_PackageVersion { get; set; }
        #endregion
        
        #region Parameter UpdateVersion_PackageVersion
        /// <summary>
        /// <para>
        /// <para>The version of the wireless gateway firmware.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_LoRaWAN_UpdateVersion_PackageVersion")]
        public System.String UpdateVersion_PackageVersion { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_SigKeyCrc
        /// <summary>
        /// <para>
        /// <para>The CRC of the signature private key to check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_LoRaWAN_SigKeyCrc")]
        public System.Int64? LoRaWAN_SigKeyCrc { get; set; }
        #endregion
        
        #region Parameter CurrentVersion_Station
        /// <summary>
        /// <para>
        /// <para>The basic station version of the wireless gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_LoRaWAN_CurrentVersion_Station")]
        public System.String CurrentVersion_Station { get; set; }
        #endregion
        
        #region Parameter UpdateVersion_Station
        /// <summary>
        /// <para>
        /// <para>The basic station version of the wireless gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_LoRaWAN_UpdateVersion_Station")]
        public System.String UpdateVersion_Station { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to attach to the specified resource. Tags are metadata that you can use to
        /// manage a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Update_UpdateDataRole
        /// <summary>
        /// <para>
        /// <para>The IAM role used to read data from the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Update_UpdateDataRole { get; set; }
        #endregion
        
        #region Parameter Update_UpdateDataSource
        /// <summary>
        /// <para>
        /// <para>The link to the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Update_UpdateDataSource { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_UpdateSignature
        /// <summary>
        /// <para>
        /// <para>The signature used to verify the update firmware.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Update_LoRaWAN_UpdateSignature")]
        public System.String LoRaWAN_UpdateSignature { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoCreateTask parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoCreateTask' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoCreateTask' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTWWirelessGatewayTaskDefinition (CreateWirelessGatewayTaskDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionResponse, NewIOTWWirelessGatewayTaskDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoCreateTask;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoCreateTask = this.AutoCreateTask;
            #if MODULAR
            if (this.AutoCreateTask == null && ParameterWasBound(nameof(this.AutoCreateTask)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoCreateTask which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTWireless.Model.Tag>(this.Tag);
            }
            context.CurrentVersion_Model = this.CurrentVersion_Model;
            context.CurrentVersion_PackageVersion = this.CurrentVersion_PackageVersion;
            context.CurrentVersion_Station = this.CurrentVersion_Station;
            context.LoRaWAN_SigKeyCrc = this.LoRaWAN_SigKeyCrc;
            context.LoRaWAN_UpdateSignature = this.LoRaWAN_UpdateSignature;
            context.UpdateVersion_Model = this.UpdateVersion_Model;
            context.UpdateVersion_PackageVersion = this.UpdateVersion_PackageVersion;
            context.UpdateVersion_Station = this.UpdateVersion_Station;
            context.Update_UpdateDataRole = this.Update_UpdateDataRole;
            context.Update_UpdateDataSource = this.Update_UpdateDataSource;
            
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
            var request = new Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionRequest();
            
            if (cmdletContext.AutoCreateTask != null)
            {
                request.AutoCreateTasks = cmdletContext.AutoCreateTask.Value;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Update
            var requestUpdateIsNull = true;
            request.Update = new Amazon.IoTWireless.Model.UpdateWirelessGatewayTaskCreate();
            System.String requestUpdate_update_UpdateDataRole = null;
            if (cmdletContext.Update_UpdateDataRole != null)
            {
                requestUpdate_update_UpdateDataRole = cmdletContext.Update_UpdateDataRole;
            }
            if (requestUpdate_update_UpdateDataRole != null)
            {
                request.Update.UpdateDataRole = requestUpdate_update_UpdateDataRole;
                requestUpdateIsNull = false;
            }
            System.String requestUpdate_update_UpdateDataSource = null;
            if (cmdletContext.Update_UpdateDataSource != null)
            {
                requestUpdate_update_UpdateDataSource = cmdletContext.Update_UpdateDataSource;
            }
            if (requestUpdate_update_UpdateDataSource != null)
            {
                request.Update.UpdateDataSource = requestUpdate_update_UpdateDataSource;
                requestUpdateIsNull = false;
            }
            Amazon.IoTWireless.Model.LoRaWANUpdateGatewayTaskCreate requestUpdate_update_LoRaWAN = null;
            
             // populate LoRaWAN
            var requestUpdate_update_LoRaWANIsNull = true;
            requestUpdate_update_LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANUpdateGatewayTaskCreate();
            System.Int64? requestUpdate_update_LoRaWAN_loRaWAN_SigKeyCrc = null;
            if (cmdletContext.LoRaWAN_SigKeyCrc != null)
            {
                requestUpdate_update_LoRaWAN_loRaWAN_SigKeyCrc = cmdletContext.LoRaWAN_SigKeyCrc.Value;
            }
            if (requestUpdate_update_LoRaWAN_loRaWAN_SigKeyCrc != null)
            {
                requestUpdate_update_LoRaWAN.SigKeyCrc = requestUpdate_update_LoRaWAN_loRaWAN_SigKeyCrc.Value;
                requestUpdate_update_LoRaWANIsNull = false;
            }
            System.String requestUpdate_update_LoRaWAN_loRaWAN_UpdateSignature = null;
            if (cmdletContext.LoRaWAN_UpdateSignature != null)
            {
                requestUpdate_update_LoRaWAN_loRaWAN_UpdateSignature = cmdletContext.LoRaWAN_UpdateSignature;
            }
            if (requestUpdate_update_LoRaWAN_loRaWAN_UpdateSignature != null)
            {
                requestUpdate_update_LoRaWAN.UpdateSignature = requestUpdate_update_LoRaWAN_loRaWAN_UpdateSignature;
                requestUpdate_update_LoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.LoRaWANGatewayVersion requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion = null;
            
             // populate CurrentVersion
            var requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersionIsNull = true;
            requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion = new Amazon.IoTWireless.Model.LoRaWANGatewayVersion();
            System.String requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_Model = null;
            if (cmdletContext.CurrentVersion_Model != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_Model = cmdletContext.CurrentVersion_Model;
            }
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_Model != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion.Model = requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_Model;
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersionIsNull = false;
            }
            System.String requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_PackageVersion = null;
            if (cmdletContext.CurrentVersion_PackageVersion != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_PackageVersion = cmdletContext.CurrentVersion_PackageVersion;
            }
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_PackageVersion != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion.PackageVersion = requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_PackageVersion;
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersionIsNull = false;
            }
            System.String requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_Station = null;
            if (cmdletContext.CurrentVersion_Station != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_Station = cmdletContext.CurrentVersion_Station;
            }
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_Station != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion.Station = requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion_currentVersion_Station;
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersionIsNull = false;
            }
             // determine if requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion should be set to null
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersionIsNull)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion = null;
            }
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion != null)
            {
                requestUpdate_update_LoRaWAN.CurrentVersion = requestUpdate_update_LoRaWAN_update_LoRaWAN_CurrentVersion;
                requestUpdate_update_LoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.LoRaWANGatewayVersion requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion = null;
            
             // populate UpdateVersion
            var requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersionIsNull = true;
            requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion = new Amazon.IoTWireless.Model.LoRaWANGatewayVersion();
            System.String requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_Model = null;
            if (cmdletContext.UpdateVersion_Model != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_Model = cmdletContext.UpdateVersion_Model;
            }
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_Model != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion.Model = requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_Model;
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersionIsNull = false;
            }
            System.String requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_PackageVersion = null;
            if (cmdletContext.UpdateVersion_PackageVersion != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_PackageVersion = cmdletContext.UpdateVersion_PackageVersion;
            }
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_PackageVersion != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion.PackageVersion = requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_PackageVersion;
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersionIsNull = false;
            }
            System.String requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_Station = null;
            if (cmdletContext.UpdateVersion_Station != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_Station = cmdletContext.UpdateVersion_Station;
            }
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_Station != null)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion.Station = requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion_updateVersion_Station;
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersionIsNull = false;
            }
             // determine if requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion should be set to null
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersionIsNull)
            {
                requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion = null;
            }
            if (requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion != null)
            {
                requestUpdate_update_LoRaWAN.UpdateVersion = requestUpdate_update_LoRaWAN_update_LoRaWAN_UpdateVersion;
                requestUpdate_update_LoRaWANIsNull = false;
            }
             // determine if requestUpdate_update_LoRaWAN should be set to null
            if (requestUpdate_update_LoRaWANIsNull)
            {
                requestUpdate_update_LoRaWAN = null;
            }
            if (requestUpdate_update_LoRaWAN != null)
            {
                request.Update.LoRaWAN = requestUpdate_update_LoRaWAN;
                requestUpdateIsNull = false;
            }
             // determine if request.Update should be set to null
            if (requestUpdateIsNull)
            {
                request.Update = null;
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
        
        private Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "CreateWirelessGatewayTaskDefinition");
            try
            {
                #if DESKTOP
                return client.CreateWirelessGatewayTaskDefinition(request);
                #elif CORECLR
                return client.CreateWirelessGatewayTaskDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AutoCreateTask { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public System.String CurrentVersion_Model { get; set; }
            public System.String CurrentVersion_PackageVersion { get; set; }
            public System.String CurrentVersion_Station { get; set; }
            public System.Int64? LoRaWAN_SigKeyCrc { get; set; }
            public System.String LoRaWAN_UpdateSignature { get; set; }
            public System.String UpdateVersion_Model { get; set; }
            public System.String UpdateVersion_PackageVersion { get; set; }
            public System.String UpdateVersion_Station { get; set; }
            public System.String Update_UpdateDataRole { get; set; }
            public System.String Update_UpdateDataSource { get; set; }
            public System.Func<Amazon.IoTWireless.Model.CreateWirelessGatewayTaskDefinitionResponse, NewIOTWWirelessGatewayTaskDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
