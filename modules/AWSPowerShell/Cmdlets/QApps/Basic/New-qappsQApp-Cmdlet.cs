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
using Amazon.QApps;
using Amazon.QApps.Model;

namespace Amazon.PowerShell.Cmdlets.qapps
{
    /// <summary>
    /// Creates a new Amazon Q App based on the provided definition. The Q App definition
    /// specifies the cards and flow of the Q App. This operation also calculates the dependencies
    /// between the cards by inspecting the references in the prompts.
    /// </summary>
    [Cmdlet("New", "qappsQApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QApps.Model.CreateQAppResponse")]
    [AWSCmdlet("Calls the Amazon Q Apps CreateQApp API operation.", Operation = new[] {"CreateQApp"}, SelectReturnType = typeof(Amazon.QApps.Model.CreateQAppResponse))]
    [AWSCmdletOutput("Amazon.QApps.Model.CreateQAppResponse",
        "This cmdlet returns an Amazon.QApps.Model.CreateQAppResponse object containing multiple properties."
    )]
    public partial class NewqappsQAppCmdlet : AmazonQAppsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppDefinition_Card
        /// <summary>
        /// <para>
        /// <para>The cards that make up the Q App definition.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AppDefinition_Cards")]
        public Amazon.QApps.Model.CardInput[] AppDefinition_Card { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the new Q App.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AppDefinition_InitialPrompt
        /// <summary>
        /// <para>
        /// <para>The initial prompt displayed when the Q App is started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppDefinition_InitialPrompt { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon Q Business application environment instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional tags to associate with the new Q App.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title of the new Q App.</para>
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
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QApps.Model.CreateQAppResponse).
        /// Specifying the name of a property of type Amazon.QApps.Model.CreateQAppResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-qappsQApp (CreateQApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QApps.Model.CreateQAppResponse, NewqappsQAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AppDefinition_Card != null)
            {
                context.AppDefinition_Card = new List<Amazon.QApps.Model.CardInput>(this.AppDefinition_Card);
            }
            #if MODULAR
            if (this.AppDefinition_Card == null && ParameterWasBound(nameof(this.AppDefinition_Card)))
            {
                WriteWarning("You are passing $null as a value for parameter AppDefinition_Card which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppDefinition_InitialPrompt = this.AppDefinition_InitialPrompt;
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.Title = this.Title;
            #if MODULAR
            if (this.Title == null && ParameterWasBound(nameof(this.Title)))
            {
                WriteWarning("You are passing $null as a value for parameter Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QApps.Model.CreateQAppRequest();
            
            
             // populate AppDefinition
            var requestAppDefinitionIsNull = true;
            request.AppDefinition = new Amazon.QApps.Model.AppDefinitionInput();
            List<Amazon.QApps.Model.CardInput> requestAppDefinition_appDefinition_Card = null;
            if (cmdletContext.AppDefinition_Card != null)
            {
                requestAppDefinition_appDefinition_Card = cmdletContext.AppDefinition_Card;
            }
            if (requestAppDefinition_appDefinition_Card != null)
            {
                request.AppDefinition.Cards = requestAppDefinition_appDefinition_Card;
                requestAppDefinitionIsNull = false;
            }
            System.String requestAppDefinition_appDefinition_InitialPrompt = null;
            if (cmdletContext.AppDefinition_InitialPrompt != null)
            {
                requestAppDefinition_appDefinition_InitialPrompt = cmdletContext.AppDefinition_InitialPrompt;
            }
            if (requestAppDefinition_appDefinition_InitialPrompt != null)
            {
                request.AppDefinition.InitialPrompt = requestAppDefinition_appDefinition_InitialPrompt;
                requestAppDefinitionIsNull = false;
            }
             // determine if request.AppDefinition should be set to null
            if (requestAppDefinitionIsNull)
            {
                request.AppDefinition = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.QApps.Model.CreateQAppResponse CallAWSServiceOperation(IAmazonQApps client, Amazon.QApps.Model.CreateQAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Apps", "CreateQApp");
            try
            {
                return client.CreateQAppAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.QApps.Model.CardInput> AppDefinition_Card { get; set; }
            public System.String AppDefinition_InitialPrompt { get; set; }
            public System.String Description { get; set; }
            public System.String InstanceId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.QApps.Model.CreateQAppResponse, NewqappsQAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
