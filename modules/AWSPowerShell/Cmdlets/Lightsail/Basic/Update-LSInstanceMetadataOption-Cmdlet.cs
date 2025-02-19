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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Modifies the Amazon Lightsail instance metadata parameters on a running or stopped
    /// instance. When you modify the parameters on a running instance, the <c>GetInstance</c>
    /// or <c>GetInstances</c> API operation initially responds with a state of <c>pending</c>.
    /// After the parameter modifications are successfully applied, the state changes to <c>applied</c>
    /// in subsequent <c>GetInstance</c> or <c>GetInstances</c> API calls. For more information,
    /// see <a href="https://docs.aws.amazon.com/lightsail/latest/userguide/amazon-lightsail-configuring-instance-metadata-service">Use
    /// IMDSv2 with an Amazon Lightsail instance</a> in the <i>Amazon Lightsail Developer
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Update", "LSInstanceMetadataOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail UpdateInstanceMetadataOptions API operation.", Operation = new[] {"UpdateInstanceMetadataOptions"}, SelectReturnType = typeof(Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.Operation object.",
        "The service call response (type Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateLSInstanceMetadataOptionCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter HttpEndpoint
        /// <summary>
        /// <para>
        /// <para>Enables or disables the HTTP metadata endpoint on your instances. If this parameter
        /// is not specified, the existing state is maintained.</para><para>If you specify a value of <c>disabled</c>, you cannot access your instance metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.HttpEndpoint")]
        public Amazon.Lightsail.HttpEndpoint HttpEndpoint { get; set; }
        #endregion
        
        #region Parameter HttpProtocolIpv6
        /// <summary>
        /// <para>
        /// <para>Enables or disables the IPv6 endpoint for the instance metadata service. This setting
        /// applies only when the HTTP metadata endpoint is enabled.</para><note><para>This parameter is available only for instances in the Europe (Stockholm) Amazon Web
        /// Services Region (<c>eu-north-1</c>).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.HttpProtocolIpv6")]
        public Amazon.Lightsail.HttpProtocolIpv6 HttpProtocolIpv6 { get; set; }
        #endregion
        
        #region Parameter HttpPutResponseHopLimit
        /// <summary>
        /// <para>
        /// <para>The desired HTTP PUT response hop limit for instance metadata requests. A larger number
        /// means that the instance metadata requests can travel farther. If no parameter is specified,
        /// the existing state is maintained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HttpPutResponseHopLimit { get; set; }
        #endregion
        
        #region Parameter HttpToken
        /// <summary>
        /// <para>
        /// <para>The state of token usage for your instance metadata requests. If the parameter is
        /// not specified in the request, the default state is <c>optional</c>.</para><para>If the state is <c>optional</c>, you can choose whether to retrieve instance metadata
        /// with a signed token header on your request. If you retrieve the IAM role credentials
        /// without a token, the version 1.0 role credentials are returned. If you retrieve the
        /// IAM role credentials by using a valid signed token, the version 2.0 role credentials
        /// are returned.</para><para>If the state is <c>required</c>, you must send a signed token header with all instance
        /// metadata retrieval requests. In this state, retrieving the IAM role credential always
        /// returns the version 2.0 credentials. The version 1.0 credentials are not available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HttpTokens")]
        [AWSConstantClassSource("Amazon.Lightsail.HttpTokens")]
        public Amazon.Lightsail.HttpTokens HttpToken { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the instance for which to update metadata parameters.</para>
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
        public System.String InstanceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LSInstanceMetadataOption (UpdateInstanceMetadataOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsResponse, UpdateLSInstanceMetadataOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HttpEndpoint = this.HttpEndpoint;
            context.HttpProtocolIpv6 = this.HttpProtocolIpv6;
            context.HttpPutResponseHopLimit = this.HttpPutResponseHopLimit;
            context.HttpToken = this.HttpToken;
            context.InstanceName = this.InstanceName;
            #if MODULAR
            if (this.InstanceName == null && ParameterWasBound(nameof(this.InstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsRequest();
            
            if (cmdletContext.HttpEndpoint != null)
            {
                request.HttpEndpoint = cmdletContext.HttpEndpoint;
            }
            if (cmdletContext.HttpProtocolIpv6 != null)
            {
                request.HttpProtocolIpv6 = cmdletContext.HttpProtocolIpv6;
            }
            if (cmdletContext.HttpPutResponseHopLimit != null)
            {
                request.HttpPutResponseHopLimit = cmdletContext.HttpPutResponseHopLimit.Value;
            }
            if (cmdletContext.HttpToken != null)
            {
                request.HttpTokens = cmdletContext.HttpToken;
            }
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
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
        
        private Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "UpdateInstanceMetadataOptions");
            try
            {
                #if DESKTOP
                return client.UpdateInstanceMetadataOptions(request);
                #elif CORECLR
                return client.UpdateInstanceMetadataOptionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Lightsail.HttpEndpoint HttpEndpoint { get; set; }
            public Amazon.Lightsail.HttpProtocolIpv6 HttpProtocolIpv6 { get; set; }
            public System.Int32? HttpPutResponseHopLimit { get; set; }
            public Amazon.Lightsail.HttpTokens HttpToken { get; set; }
            public System.String InstanceName { get; set; }
            public System.Func<Amazon.Lightsail.Model.UpdateInstanceMetadataOptionsResponse, UpdateLSInstanceMetadataOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operation;
        }
        
    }
}
