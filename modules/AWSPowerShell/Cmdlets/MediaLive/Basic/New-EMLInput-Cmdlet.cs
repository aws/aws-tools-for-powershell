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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Create an input
    /// </summary>
    [Cmdlet("New", "EMLInput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.Input")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive CreateInput API operation.", Operation = new[] {"CreateInput"}, SelectReturnType = typeof(Amazon.MediaLive.Model.CreateInputResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.Input or Amazon.MediaLive.Model.CreateInputResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.Input object.",
        "The service call response (type Amazon.MediaLive.Model.CreateInputResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEMLInputCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// Destination settings for PUSH type inputs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public Amazon.MediaLive.Model.InputDestinationRequest[] Destination { get; set; }
        #endregion
        
        #region Parameter InputDevice
        /// <summary>
        /// <para>
        /// Settings for the devices.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDevices")]
        public Amazon.MediaLive.Model.InputDeviceSettings[] InputDevice { get; set; }
        #endregion
        
        #region Parameter InputNetworkLocation
        /// <summary>
        /// <para>
        /// The location of this input. AWS,
        /// for an input existing in the AWS Cloud, On-Prem foran input in a customer network.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputNetworkLocation")]
        public Amazon.MediaLive.InputNetworkLocation InputNetworkLocation { get; set; }
        #endregion
        
        #region Parameter InputSecurityGroup
        /// <summary>
        /// <para>
        /// A list of security groups referenced
        /// by IDs to attach to the input.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputSecurityGroups")]
        public System.String[] InputSecurityGroup { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow
        /// <summary>
        /// <para>
        /// A list of the MediaConnect Flows that
        /// you want to use in this input. You can specify as few as oneFlow and presently, as
        /// many as two. The only requirement is when you have more than one is that each Flow
        /// is in aseparate Availability Zone as this ensures your EML input is redundant to AZ
        /// issues.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaConnectFlows")]
        public Amazon.MediaLive.Model.MediaConnectFlowRequest[] MediaConnectFlow { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Name of the input.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestId
        /// <summary>
        /// <para>
        /// Unique identifier of the request to ensure the
        /// request is handledexactly once in case of retries.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the role this
        /// input assumes during and after creation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Vpc_SecurityGroupId
        /// <summary>
        /// <para>
        /// A list of up to 5 EC2 VPC security group
        /// IDs to attach to the Input VPC network interfaces.Requires subnetIds. If none are
        /// specified then the VPC default security group will be used.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Vpc_SecurityGroupIds")]
        public System.String[] Vpc_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter MulticastSettings_Source
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MulticastSettings_Sources")]
        public Amazon.MediaLive.Model.MulticastSourceCreateRequest[] MulticastSettings_Source { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// The source URLs for a PULL-type input. Every PULL
        /// type input needsexactly two source URLs for redundancy.Only specify sources for PULL
        /// type Inputs. Leave Destinations empty.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sources")]
        public Amazon.MediaLive.Model.InputSourceRequest[] Source { get; set; }
        #endregion
        
        #region Parameter SrtSettings_SrtCallerSource
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SrtSettings_SrtCallerSources")]
        public Amazon.MediaLive.Model.SrtCallerSourceRequest[] SrtSettings_SrtCallerSource { get; set; }
        #endregion
        
        #region Parameter Vpc_SubnetId
        /// <summary>
        /// <para>
        /// A list of 2 VPC subnet IDs from the same VPC.Subnet
        /// IDs must be mapped to two unique availability zones (AZ).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Vpc_SubnetIds")]
        public System.String[] Vpc_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// A collection of key-value pairs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputType")]
        public Amazon.MediaLive.InputType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Input'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.CreateInputResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.CreateInputResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Input";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMLInput (CreateInput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.CreateInputResponse, NewEMLInputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.MediaLive.Model.InputDestinationRequest>(this.Destination);
            }
            if (this.InputDevice != null)
            {
                context.InputDevice = new List<Amazon.MediaLive.Model.InputDeviceSettings>(this.InputDevice);
            }
            context.InputNetworkLocation = this.InputNetworkLocation;
            if (this.InputSecurityGroup != null)
            {
                context.InputSecurityGroup = new List<System.String>(this.InputSecurityGroup);
            }
            if (this.MediaConnectFlow != null)
            {
                context.MediaConnectFlow = new List<Amazon.MediaLive.Model.MediaConnectFlowRequest>(this.MediaConnectFlow);
            }
            if (this.MulticastSettings_Source != null)
            {
                context.MulticastSettings_Source = new List<Amazon.MediaLive.Model.MulticastSourceCreateRequest>(this.MulticastSettings_Source);
            }
            context.Name = this.Name;
            context.RequestId = this.RequestId;
            context.RoleArn = this.RoleArn;
            if (this.Source != null)
            {
                context.Source = new List<Amazon.MediaLive.Model.InputSourceRequest>(this.Source);
            }
            if (this.SrtSettings_SrtCallerSource != null)
            {
                context.SrtSettings_SrtCallerSource = new List<Amazon.MediaLive.Model.SrtCallerSourceRequest>(this.SrtSettings_SrtCallerSource);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            if (this.Vpc_SecurityGroupId != null)
            {
                context.Vpc_SecurityGroupId = new List<System.String>(this.Vpc_SecurityGroupId);
            }
            if (this.Vpc_SubnetId != null)
            {
                context.Vpc_SubnetId = new List<System.String>(this.Vpc_SubnetId);
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
            var request = new Amazon.MediaLive.Model.CreateInputRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.InputDevice != null)
            {
                request.InputDevices = cmdletContext.InputDevice;
            }
            if (cmdletContext.InputNetworkLocation != null)
            {
                request.InputNetworkLocation = cmdletContext.InputNetworkLocation;
            }
            if (cmdletContext.InputSecurityGroup != null)
            {
                request.InputSecurityGroups = cmdletContext.InputSecurityGroup;
            }
            if (cmdletContext.MediaConnectFlow != null)
            {
                request.MediaConnectFlows = cmdletContext.MediaConnectFlow;
            }
            
             // populate MulticastSettings
            var requestMulticastSettingsIsNull = true;
            request.MulticastSettings = new Amazon.MediaLive.Model.MulticastSettingsCreateRequest();
            List<Amazon.MediaLive.Model.MulticastSourceCreateRequest> requestMulticastSettings_multicastSettings_Source = null;
            if (cmdletContext.MulticastSettings_Source != null)
            {
                requestMulticastSettings_multicastSettings_Source = cmdletContext.MulticastSettings_Source;
            }
            if (requestMulticastSettings_multicastSettings_Source != null)
            {
                request.MulticastSettings.Sources = requestMulticastSettings_multicastSettings_Source;
                requestMulticastSettingsIsNull = false;
            }
             // determine if request.MulticastSettings should be set to null
            if (requestMulticastSettingsIsNull)
            {
                request.MulticastSettings = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            
             // populate SrtSettings
            var requestSrtSettingsIsNull = true;
            request.SrtSettings = new Amazon.MediaLive.Model.SrtSettingsRequest();
            List<Amazon.MediaLive.Model.SrtCallerSourceRequest> requestSrtSettings_srtSettings_SrtCallerSource = null;
            if (cmdletContext.SrtSettings_SrtCallerSource != null)
            {
                requestSrtSettings_srtSettings_SrtCallerSource = cmdletContext.SrtSettings_SrtCallerSource;
            }
            if (requestSrtSettings_srtSettings_SrtCallerSource != null)
            {
                request.SrtSettings.SrtCallerSources = requestSrtSettings_srtSettings_SrtCallerSource;
                requestSrtSettingsIsNull = false;
            }
             // determine if request.SrtSettings should be set to null
            if (requestSrtSettingsIsNull)
            {
                request.SrtSettings = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
             // populate Vpc
            var requestVpcIsNull = true;
            request.Vpc = new Amazon.MediaLive.Model.InputVpcRequest();
            List<System.String> requestVpc_vpc_SecurityGroupId = null;
            if (cmdletContext.Vpc_SecurityGroupId != null)
            {
                requestVpc_vpc_SecurityGroupId = cmdletContext.Vpc_SecurityGroupId;
            }
            if (requestVpc_vpc_SecurityGroupId != null)
            {
                request.Vpc.SecurityGroupIds = requestVpc_vpc_SecurityGroupId;
                requestVpcIsNull = false;
            }
            List<System.String> requestVpc_vpc_SubnetId = null;
            if (cmdletContext.Vpc_SubnetId != null)
            {
                requestVpc_vpc_SubnetId = cmdletContext.Vpc_SubnetId;
            }
            if (requestVpc_vpc_SubnetId != null)
            {
                request.Vpc.SubnetIds = requestVpc_vpc_SubnetId;
                requestVpcIsNull = false;
            }
             // determine if request.Vpc should be set to null
            if (requestVpcIsNull)
            {
                request.Vpc = null;
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
        
        private Amazon.MediaLive.Model.CreateInputResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.CreateInputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "CreateInput");
            try
            {
                return client.CreateInputAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.MediaLive.Model.InputDestinationRequest> Destination { get; set; }
            public List<Amazon.MediaLive.Model.InputDeviceSettings> InputDevice { get; set; }
            public Amazon.MediaLive.InputNetworkLocation InputNetworkLocation { get; set; }
            public List<System.String> InputSecurityGroup { get; set; }
            public List<Amazon.MediaLive.Model.MediaConnectFlowRequest> MediaConnectFlow { get; set; }
            public List<Amazon.MediaLive.Model.MulticastSourceCreateRequest> MulticastSettings_Source { get; set; }
            public System.String Name { get; set; }
            public System.String RequestId { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.MediaLive.Model.InputSourceRequest> Source { get; set; }
            public List<Amazon.MediaLive.Model.SrtCallerSourceRequest> SrtSettings_SrtCallerSource { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.MediaLive.InputType Type { get; set; }
            public List<System.String> Vpc_SecurityGroupId { get; set; }
            public List<System.String> Vpc_SubnetId { get; set; }
            public System.Func<Amazon.MediaLive.Model.CreateInputResponse, NewEMLInputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Input;
        }
        
    }
}
