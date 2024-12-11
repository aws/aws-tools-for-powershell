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
using Amazon.Greengrass;
using Amazon.Greengrass.Model;

namespace Amazon.PowerShell.Cmdlets.GG
{
    /// <summary>
    /// Creates a group. You may provide the initial version of the group or use ''CreateGroupVersion''
    /// at a later time. Tip: You can use the ''gg_group_setup'' package (https://github.com/awslabs/aws-greengrass-group-setup)
    /// as a library or command-line application to create and deploy Greengrass groups.
    /// </summary>
    [Cmdlet("New", "GGGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Greengrass.Model.CreateGroupResponse")]
    [AWSCmdlet("Calls the AWS Greengrass CreateGroup API operation.", Operation = new[] {"CreateGroup"}, SelectReturnType = typeof(Amazon.Greengrass.Model.CreateGroupResponse))]
    [AWSCmdletOutput("Amazon.Greengrass.Model.CreateGroupResponse",
        "This cmdlet returns an Amazon.Greengrass.Model.CreateGroupResponse object containing multiple properties."
    )]
    public partial class NewGGGroupCmdlet : AmazonGreengrassClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AmznClientToken
        /// <summary>
        /// <para>
        /// A client token used to correlate requests
        /// and responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmznClientToken { get; set; }
        #endregion
        
        #region Parameter InitialVersion_ConnectorDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the connector
        /// definition version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialVersion_ConnectorDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter InitialVersion_CoreDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the core definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialVersion_CoreDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter InitialVersion_DeviceDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the device definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialVersion_DeviceDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter InitialVersion_FunctionDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the function definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialVersion_FunctionDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter InitialVersion_LoggerDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the logger definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialVersion_LoggerDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the group.
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
        
        #region Parameter InitialVersion_ResourceDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the resource definition
        /// version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialVersion_ResourceDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter InitialVersion_SubscriptionDefinitionVersionArn
        /// <summary>
        /// <para>
        /// The ARN of the subscription
        /// definition version for this group.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialVersion_SubscriptionDefinitionVersionArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// Tag(s) to add to the new resource.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Greengrass.Model.CreateGroupResponse).
        /// Specifying the name of a property of type Amazon.Greengrass.Model.CreateGroupResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GGGroup (CreateGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Greengrass.Model.CreateGroupResponse, NewGGGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmznClientToken = this.AmznClientToken;
            context.InitialVersion_ConnectorDefinitionVersionArn = this.InitialVersion_ConnectorDefinitionVersionArn;
            context.InitialVersion_CoreDefinitionVersionArn = this.InitialVersion_CoreDefinitionVersionArn;
            context.InitialVersion_DeviceDefinitionVersionArn = this.InitialVersion_DeviceDefinitionVersionArn;
            context.InitialVersion_FunctionDefinitionVersionArn = this.InitialVersion_FunctionDefinitionVersionArn;
            context.InitialVersion_LoggerDefinitionVersionArn = this.InitialVersion_LoggerDefinitionVersionArn;
            context.InitialVersion_ResourceDefinitionVersionArn = this.InitialVersion_ResourceDefinitionVersionArn;
            context.InitialVersion_SubscriptionDefinitionVersionArn = this.InitialVersion_SubscriptionDefinitionVersionArn;
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
            var request = new Amazon.Greengrass.Model.CreateGroupRequest();
            
            if (cmdletContext.AmznClientToken != null)
            {
                request.AmznClientToken = cmdletContext.AmznClientToken;
            }
            
             // populate InitialVersion
            var requestInitialVersionIsNull = true;
            request.InitialVersion = new Amazon.Greengrass.Model.GroupVersion();
            System.String requestInitialVersion_initialVersion_ConnectorDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_ConnectorDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_ConnectorDefinitionVersionArn = cmdletContext.InitialVersion_ConnectorDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_ConnectorDefinitionVersionArn != null)
            {
                request.InitialVersion.ConnectorDefinitionVersionArn = requestInitialVersion_initialVersion_ConnectorDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_CoreDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_CoreDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_CoreDefinitionVersionArn = cmdletContext.InitialVersion_CoreDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_CoreDefinitionVersionArn != null)
            {
                request.InitialVersion.CoreDefinitionVersionArn = requestInitialVersion_initialVersion_CoreDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_DeviceDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_DeviceDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_DeviceDefinitionVersionArn = cmdletContext.InitialVersion_DeviceDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_DeviceDefinitionVersionArn != null)
            {
                request.InitialVersion.DeviceDefinitionVersionArn = requestInitialVersion_initialVersion_DeviceDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_FunctionDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_FunctionDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_FunctionDefinitionVersionArn = cmdletContext.InitialVersion_FunctionDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_FunctionDefinitionVersionArn != null)
            {
                request.InitialVersion.FunctionDefinitionVersionArn = requestInitialVersion_initialVersion_FunctionDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_LoggerDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_LoggerDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_LoggerDefinitionVersionArn = cmdletContext.InitialVersion_LoggerDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_LoggerDefinitionVersionArn != null)
            {
                request.InitialVersion.LoggerDefinitionVersionArn = requestInitialVersion_initialVersion_LoggerDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_ResourceDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_ResourceDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_ResourceDefinitionVersionArn = cmdletContext.InitialVersion_ResourceDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_ResourceDefinitionVersionArn != null)
            {
                request.InitialVersion.ResourceDefinitionVersionArn = requestInitialVersion_initialVersion_ResourceDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
            System.String requestInitialVersion_initialVersion_SubscriptionDefinitionVersionArn = null;
            if (cmdletContext.InitialVersion_SubscriptionDefinitionVersionArn != null)
            {
                requestInitialVersion_initialVersion_SubscriptionDefinitionVersionArn = cmdletContext.InitialVersion_SubscriptionDefinitionVersionArn;
            }
            if (requestInitialVersion_initialVersion_SubscriptionDefinitionVersionArn != null)
            {
                request.InitialVersion.SubscriptionDefinitionVersionArn = requestInitialVersion_initialVersion_SubscriptionDefinitionVersionArn;
                requestInitialVersionIsNull = false;
            }
             // determine if request.InitialVersion should be set to null
            if (requestInitialVersionIsNull)
            {
                request.InitialVersion = null;
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
        
        private Amazon.Greengrass.Model.CreateGroupResponse CallAWSServiceOperation(IAmazonGreengrass client, Amazon.Greengrass.Model.CreateGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Greengrass", "CreateGroup");
            try
            {
                #if DESKTOP
                return client.CreateGroup(request);
                #elif CORECLR
                return client.CreateGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String AmznClientToken { get; set; }
            public System.String InitialVersion_ConnectorDefinitionVersionArn { get; set; }
            public System.String InitialVersion_CoreDefinitionVersionArn { get; set; }
            public System.String InitialVersion_DeviceDefinitionVersionArn { get; set; }
            public System.String InitialVersion_FunctionDefinitionVersionArn { get; set; }
            public System.String InitialVersion_LoggerDefinitionVersionArn { get; set; }
            public System.String InitialVersion_ResourceDefinitionVersionArn { get; set; }
            public System.String InitialVersion_SubscriptionDefinitionVersionArn { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Greengrass.Model.CreateGroupResponse, NewGGGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
