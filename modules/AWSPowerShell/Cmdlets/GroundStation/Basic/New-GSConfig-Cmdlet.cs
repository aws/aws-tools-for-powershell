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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// Creates a <c>Config</c> with the specified <c>configData</c> parameters.
    /// 
    ///  
    /// <para>
    /// Only one type of <c>configData</c> can be specified.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GSConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GroundStation.Model.CreateConfigResponse")]
    [AWSCmdlet("Calls the AWS Ground Station CreateConfig API operation.", Operation = new[] {"CreateConfig"}, SelectReturnType = typeof(Amazon.GroundStation.Model.CreateConfigResponse))]
    [AWSCmdletOutput("Amazon.GroundStation.Model.CreateConfigResponse",
        "This cmdlet returns an Amazon.GroundStation.Model.CreateConfigResponse object containing multiple properties."
    )]
    public partial class NewGSConfigCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigData_AntennaDownlinkConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should configure an antenna for downlink
        /// during a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaDownlinkConfig ConfigData_AntennaDownlinkConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_AntennaDownlinkDemodDecodeConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should conﬁgure an antenna for downlink demod
        /// decode during a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig ConfigData_AntennaDownlinkDemodDecodeConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_AntennaUplinkConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should conﬁgure an antenna for uplink during
        /// a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaUplinkConfig ConfigData_AntennaUplinkConfig { get; set; }
        #endregion
        
        #region Parameter S3RecordingConfig_BucketArn
        /// <summary>
        /// <para>
        /// <para>ARN of the bucket to record to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigData_S3RecordingConfig_BucketArn")]
        public System.String S3RecordingConfig_BucketArn { get; set; }
        #endregion
        
        #region Parameter ConfigData_DataflowEndpointConfig
        /// <summary>
        /// <para>
        /// <para>Information about the dataflow endpoint <c>Config</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.DataflowEndpointConfig ConfigData_DataflowEndpointConfig { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of a <c>Config</c>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3RecordingConfig_Prefix
        /// <summary>
        /// <para>
        /// <para>S3 Key prefix to prefice data files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigData_S3RecordingConfig_Prefix")]
        public System.String S3RecordingConfig_Prefix { get; set; }
        #endregion
        
        #region Parameter S3RecordingConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>ARN of the role Ground Station assumes to write data to the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigData_S3RecordingConfig_RoleArn")]
        public System.String S3RecordingConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags assigned to a <c>Config</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ConfigData_TrackingConfig
        /// <summary>
        /// <para>
        /// <para>Object that determines whether tracking should be used during a contact executed with
        /// this <c>Config</c> in the mission profile. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.TrackingConfig ConfigData_TrackingConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_UplinkEchoConfig
        /// <summary>
        /// <para>
        /// <para>Information about an uplink echo <c>Config</c>.</para><para>Parameters from the <c>AntennaUplinkConfig</c>, corresponding to the specified <c>AntennaUplinkConfigArn</c>,
        /// are used when this <c>UplinkEchoConfig</c> is used in a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.UplinkEchoConfig ConfigData_UplinkEchoConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.CreateConfigResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.CreateConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GSConfig (CreateConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.CreateConfigResponse, NewGSConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigData_AntennaDownlinkConfig = this.ConfigData_AntennaDownlinkConfig;
            context.ConfigData_AntennaDownlinkDemodDecodeConfig = this.ConfigData_AntennaDownlinkDemodDecodeConfig;
            context.ConfigData_AntennaUplinkConfig = this.ConfigData_AntennaUplinkConfig;
            context.ConfigData_DataflowEndpointConfig = this.ConfigData_DataflowEndpointConfig;
            context.S3RecordingConfig_BucketArn = this.S3RecordingConfig_BucketArn;
            context.S3RecordingConfig_Prefix = this.S3RecordingConfig_Prefix;
            context.S3RecordingConfig_RoleArn = this.S3RecordingConfig_RoleArn;
            context.ConfigData_TrackingConfig = this.ConfigData_TrackingConfig;
            context.ConfigData_UplinkEchoConfig = this.ConfigData_UplinkEchoConfig;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GroundStation.Model.CreateConfigRequest();
            
            
             // populate ConfigData
            var requestConfigDataIsNull = true;
            request.ConfigData = new Amazon.GroundStation.Model.ConfigTypeData();
            Amazon.GroundStation.Model.AntennaDownlinkConfig requestConfigData_configData_AntennaDownlinkConfig = null;
            if (cmdletContext.ConfigData_AntennaDownlinkConfig != null)
            {
                requestConfigData_configData_AntennaDownlinkConfig = cmdletContext.ConfigData_AntennaDownlinkConfig;
            }
            if (requestConfigData_configData_AntennaDownlinkConfig != null)
            {
                request.ConfigData.AntennaDownlinkConfig = requestConfigData_configData_AntennaDownlinkConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig requestConfigData_configData_AntennaDownlinkDemodDecodeConfig = null;
            if (cmdletContext.ConfigData_AntennaDownlinkDemodDecodeConfig != null)
            {
                requestConfigData_configData_AntennaDownlinkDemodDecodeConfig = cmdletContext.ConfigData_AntennaDownlinkDemodDecodeConfig;
            }
            if (requestConfigData_configData_AntennaDownlinkDemodDecodeConfig != null)
            {
                request.ConfigData.AntennaDownlinkDemodDecodeConfig = requestConfigData_configData_AntennaDownlinkDemodDecodeConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.AntennaUplinkConfig requestConfigData_configData_AntennaUplinkConfig = null;
            if (cmdletContext.ConfigData_AntennaUplinkConfig != null)
            {
                requestConfigData_configData_AntennaUplinkConfig = cmdletContext.ConfigData_AntennaUplinkConfig;
            }
            if (requestConfigData_configData_AntennaUplinkConfig != null)
            {
                request.ConfigData.AntennaUplinkConfig = requestConfigData_configData_AntennaUplinkConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.DataflowEndpointConfig requestConfigData_configData_DataflowEndpointConfig = null;
            if (cmdletContext.ConfigData_DataflowEndpointConfig != null)
            {
                requestConfigData_configData_DataflowEndpointConfig = cmdletContext.ConfigData_DataflowEndpointConfig;
            }
            if (requestConfigData_configData_DataflowEndpointConfig != null)
            {
                request.ConfigData.DataflowEndpointConfig = requestConfigData_configData_DataflowEndpointConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.TrackingConfig requestConfigData_configData_TrackingConfig = null;
            if (cmdletContext.ConfigData_TrackingConfig != null)
            {
                requestConfigData_configData_TrackingConfig = cmdletContext.ConfigData_TrackingConfig;
            }
            if (requestConfigData_configData_TrackingConfig != null)
            {
                request.ConfigData.TrackingConfig = requestConfigData_configData_TrackingConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.UplinkEchoConfig requestConfigData_configData_UplinkEchoConfig = null;
            if (cmdletContext.ConfigData_UplinkEchoConfig != null)
            {
                requestConfigData_configData_UplinkEchoConfig = cmdletContext.ConfigData_UplinkEchoConfig;
            }
            if (requestConfigData_configData_UplinkEchoConfig != null)
            {
                request.ConfigData.UplinkEchoConfig = requestConfigData_configData_UplinkEchoConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.S3RecordingConfig requestConfigData_configData_S3RecordingConfig = null;
            
             // populate S3RecordingConfig
            var requestConfigData_configData_S3RecordingConfigIsNull = true;
            requestConfigData_configData_S3RecordingConfig = new Amazon.GroundStation.Model.S3RecordingConfig();
            System.String requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_BucketArn = null;
            if (cmdletContext.S3RecordingConfig_BucketArn != null)
            {
                requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_BucketArn = cmdletContext.S3RecordingConfig_BucketArn;
            }
            if (requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_BucketArn != null)
            {
                requestConfigData_configData_S3RecordingConfig.BucketArn = requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_BucketArn;
                requestConfigData_configData_S3RecordingConfigIsNull = false;
            }
            System.String requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_Prefix = null;
            if (cmdletContext.S3RecordingConfig_Prefix != null)
            {
                requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_Prefix = cmdletContext.S3RecordingConfig_Prefix;
            }
            if (requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_Prefix != null)
            {
                requestConfigData_configData_S3RecordingConfig.Prefix = requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_Prefix;
                requestConfigData_configData_S3RecordingConfigIsNull = false;
            }
            System.String requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_RoleArn = null;
            if (cmdletContext.S3RecordingConfig_RoleArn != null)
            {
                requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_RoleArn = cmdletContext.S3RecordingConfig_RoleArn;
            }
            if (requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_RoleArn != null)
            {
                requestConfigData_configData_S3RecordingConfig.RoleArn = requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_RoleArn;
                requestConfigData_configData_S3RecordingConfigIsNull = false;
            }
             // determine if requestConfigData_configData_S3RecordingConfig should be set to null
            if (requestConfigData_configData_S3RecordingConfigIsNull)
            {
                requestConfigData_configData_S3RecordingConfig = null;
            }
            if (requestConfigData_configData_S3RecordingConfig != null)
            {
                request.ConfigData.S3RecordingConfig = requestConfigData_configData_S3RecordingConfig;
                requestConfigDataIsNull = false;
            }
             // determine if request.ConfigData should be set to null
            if (requestConfigDataIsNull)
            {
                request.ConfigData = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.GroundStation.Model.CreateConfigResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.CreateConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "CreateConfig");
            try
            {
                #if DESKTOP
                return client.CreateConfig(request);
                #elif CORECLR
                return client.CreateConfigAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GroundStation.Model.AntennaDownlinkConfig ConfigData_AntennaDownlinkConfig { get; set; }
            public Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig ConfigData_AntennaDownlinkDemodDecodeConfig { get; set; }
            public Amazon.GroundStation.Model.AntennaUplinkConfig ConfigData_AntennaUplinkConfig { get; set; }
            public Amazon.GroundStation.Model.DataflowEndpointConfig ConfigData_DataflowEndpointConfig { get; set; }
            public System.String S3RecordingConfig_BucketArn { get; set; }
            public System.String S3RecordingConfig_Prefix { get; set; }
            public System.String S3RecordingConfig_RoleArn { get; set; }
            public Amazon.GroundStation.Model.TrackingConfig ConfigData_TrackingConfig { get; set; }
            public Amazon.GroundStation.Model.UplinkEchoConfig ConfigData_UplinkEchoConfig { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GroundStation.Model.CreateConfigResponse, NewGSConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
