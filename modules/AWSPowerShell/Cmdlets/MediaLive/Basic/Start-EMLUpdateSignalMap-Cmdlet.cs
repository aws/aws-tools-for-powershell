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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Initiates an update for the specified signal map. Will discover a new signal map if
    /// a changed discoveryEntryPointArn is provided.
    /// </summary>
    [Cmdlet("Start", "EMLUpdateSignalMap", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.StartUpdateSignalMapResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive StartUpdateSignalMap API operation.", Operation = new[] {"StartUpdateSignalMap"}, SelectReturnType = typeof(Amazon.MediaLive.Model.StartUpdateSignalMapResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.StartUpdateSignalMapResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.StartUpdateSignalMapResponse object containing multiple properties."
    )]
    public partial class StartEMLUpdateSignalMapCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudWatchAlarmTemplateGroupIdentifier
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudWatchAlarmTemplateGroupIdentifiers")]
        public System.String[] CloudWatchAlarmTemplateGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A resource's optional description.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DiscoveryEntryPointArn
        /// <summary>
        /// <para>
        /// A top-level supported AWS resource
        /// ARN to discovery a signal map from.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DiscoveryEntryPointArn { get; set; }
        #endregion
        
        #region Parameter EventBridgeRuleTemplateGroupIdentifier
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventBridgeRuleTemplateGroupIdentifiers")]
        public System.String[] EventBridgeRuleTemplateGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter ForceRediscovery
        /// <summary>
        /// <para>
        /// If true, will force a rediscovery of
        /// a signal map if an unchanged discoveryEntryPointArn is provided.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceRediscovery { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// A signal map's identifier. Can be either be
        /// its id or current name.
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// A resource's name. Names must be unique within the
        /// scope of a resource type in a specific region.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.StartUpdateSignalMapResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.StartUpdateSignalMapResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EMLUpdateSignalMap (StartUpdateSignalMap)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.StartUpdateSignalMapResponse, StartEMLUpdateSignalMapCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CloudWatchAlarmTemplateGroupIdentifier != null)
            {
                context.CloudWatchAlarmTemplateGroupIdentifier = new List<System.String>(this.CloudWatchAlarmTemplateGroupIdentifier);
            }
            context.Description = this.Description;
            context.DiscoveryEntryPointArn = this.DiscoveryEntryPointArn;
            if (this.EventBridgeRuleTemplateGroupIdentifier != null)
            {
                context.EventBridgeRuleTemplateGroupIdentifier = new List<System.String>(this.EventBridgeRuleTemplateGroupIdentifier);
            }
            context.ForceRediscovery = this.ForceRediscovery;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            
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
            var request = new Amazon.MediaLive.Model.StartUpdateSignalMapRequest();
            
            if (cmdletContext.CloudWatchAlarmTemplateGroupIdentifier != null)
            {
                request.CloudWatchAlarmTemplateGroupIdentifiers = cmdletContext.CloudWatchAlarmTemplateGroupIdentifier;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DiscoveryEntryPointArn != null)
            {
                request.DiscoveryEntryPointArn = cmdletContext.DiscoveryEntryPointArn;
            }
            if (cmdletContext.EventBridgeRuleTemplateGroupIdentifier != null)
            {
                request.EventBridgeRuleTemplateGroupIdentifiers = cmdletContext.EventBridgeRuleTemplateGroupIdentifier;
            }
            if (cmdletContext.ForceRediscovery != null)
            {
                request.ForceRediscovery = cmdletContext.ForceRediscovery.Value;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
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
        
        private Amazon.MediaLive.Model.StartUpdateSignalMapResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.StartUpdateSignalMapRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "StartUpdateSignalMap");
            try
            {
                #if DESKTOP
                return client.StartUpdateSignalMap(request);
                #elif CORECLR
                return client.StartUpdateSignalMapAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CloudWatchAlarmTemplateGroupIdentifier { get; set; }
            public System.String Description { get; set; }
            public System.String DiscoveryEntryPointArn { get; set; }
            public List<System.String> EventBridgeRuleTemplateGroupIdentifier { get; set; }
            public System.Boolean? ForceRediscovery { get; set; }
            public System.String Identifier { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.MediaLive.Model.StartUpdateSignalMapResponse, StartEMLUpdateSignalMapCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
