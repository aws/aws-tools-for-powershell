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
    /// Creates a new service profile.
    /// </summary>
    [Cmdlet("New", "IOTWServiceProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTWireless.Model.CreateServiceProfileResponse")]
    [AWSCmdlet("Calls the AWS IoT Wireless CreateServiceProfile API operation.", Operation = new[] {"CreateServiceProfile"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.CreateServiceProfileResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.CreateServiceProfileResponse",
        "This cmdlet returns an Amazon.IoTWireless.Model.CreateServiceProfileResponse object containing multiple properties."
    )]
    public partial class NewIOTWServiceProfileCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoRaWAN_AddGwMetadata
        /// <summary>
        /// <para>
        /// <para>The AddGWMetaData value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoRaWAN_AddGwMetadata { get; set; }
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
        
        #region Parameter LoRaWAN_DrMax
        /// <summary>
        /// <para>
        /// <para>The DrMax value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_DrMax { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_DrMin
        /// <summary>
        /// <para>
        /// <para>The DrMin value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_DrMin { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_PrAllowed
        /// <summary>
        /// <para>
        /// <para>The PRAllowed value that describes whether passive roaming is allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoRaWAN_PrAllowed { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_RaAllowed
        /// <summary>
        /// <para>
        /// <para>The RAAllowed value that describes whether roaming activation is allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoRaWAN_RaAllowed { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to attach to the new service profile. Tags are metadata that you can use
        /// to manage a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.CreateServiceProfileResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.CreateServiceProfileResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTWServiceProfile (CreateServiceProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.CreateServiceProfileResponse, NewIOTWServiceProfileCmdlet>(Select) ??
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
            context.ClientRequestToken = this.ClientRequestToken;
            context.LoRaWAN_AddGwMetadata = this.LoRaWAN_AddGwMetadata;
            context.LoRaWAN_DrMax = this.LoRaWAN_DrMax;
            context.LoRaWAN_DrMin = this.LoRaWAN_DrMin;
            context.LoRaWAN_PrAllowed = this.LoRaWAN_PrAllowed;
            context.LoRaWAN_RaAllowed = this.LoRaWAN_RaAllowed;
            context.Name = this.Name;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTWireless.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoTWireless.Model.CreateServiceProfileRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate LoRaWAN
            var requestLoRaWANIsNull = true;
            request.LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANServiceProfile();
            System.Boolean? requestLoRaWAN_loRaWAN_AddGwMetadata = null;
            if (cmdletContext.LoRaWAN_AddGwMetadata != null)
            {
                requestLoRaWAN_loRaWAN_AddGwMetadata = cmdletContext.LoRaWAN_AddGwMetadata.Value;
            }
            if (requestLoRaWAN_loRaWAN_AddGwMetadata != null)
            {
                request.LoRaWAN.AddGwMetadata = requestLoRaWAN_loRaWAN_AddGwMetadata.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_DrMax = null;
            if (cmdletContext.LoRaWAN_DrMax != null)
            {
                requestLoRaWAN_loRaWAN_DrMax = cmdletContext.LoRaWAN_DrMax.Value;
            }
            if (requestLoRaWAN_loRaWAN_DrMax != null)
            {
                request.LoRaWAN.DrMax = requestLoRaWAN_loRaWAN_DrMax.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_DrMin = null;
            if (cmdletContext.LoRaWAN_DrMin != null)
            {
                requestLoRaWAN_loRaWAN_DrMin = cmdletContext.LoRaWAN_DrMin.Value;
            }
            if (requestLoRaWAN_loRaWAN_DrMin != null)
            {
                request.LoRaWAN.DrMin = requestLoRaWAN_loRaWAN_DrMin.Value;
                requestLoRaWANIsNull = false;
            }
            System.Boolean? requestLoRaWAN_loRaWAN_PrAllowed = null;
            if (cmdletContext.LoRaWAN_PrAllowed != null)
            {
                requestLoRaWAN_loRaWAN_PrAllowed = cmdletContext.LoRaWAN_PrAllowed.Value;
            }
            if (requestLoRaWAN_loRaWAN_PrAllowed != null)
            {
                request.LoRaWAN.PrAllowed = requestLoRaWAN_loRaWAN_PrAllowed.Value;
                requestLoRaWANIsNull = false;
            }
            System.Boolean? requestLoRaWAN_loRaWAN_RaAllowed = null;
            if (cmdletContext.LoRaWAN_RaAllowed != null)
            {
                requestLoRaWAN_loRaWAN_RaAllowed = cmdletContext.LoRaWAN_RaAllowed.Value;
            }
            if (requestLoRaWAN_loRaWAN_RaAllowed != null)
            {
                request.LoRaWAN.RaAllowed = requestLoRaWAN_loRaWAN_RaAllowed.Value;
                requestLoRaWANIsNull = false;
            }
             // determine if request.LoRaWAN should be set to null
            if (requestLoRaWANIsNull)
            {
                request.LoRaWAN = null;
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
        
        private Amazon.IoTWireless.Model.CreateServiceProfileResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.CreateServiceProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "CreateServiceProfile");
            try
            {
                #if DESKTOP
                return client.CreateServiceProfile(request);
                #elif CORECLR
                return client.CreateServiceProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? LoRaWAN_AddGwMetadata { get; set; }
            public System.Int32? LoRaWAN_DrMax { get; set; }
            public System.Int32? LoRaWAN_DrMin { get; set; }
            public System.Boolean? LoRaWAN_PrAllowed { get; set; }
            public System.Boolean? LoRaWAN_RaAllowed { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoTWireless.Model.CreateServiceProfileResponse, NewIOTWServiceProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
