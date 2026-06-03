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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Creates a new WhatsApp Flow. Flows enable businesses to create rich, interactive forms
    /// and experiences that users can complete without leaving WhatsApp. The Flow is created
    /// in DRAFT status. If <c>publish</c> is set to <c>true</c> and a valid <c>flowJson</c>
    /// is provided, the Flow is published immediately.
    /// </summary>
    [Cmdlet("New", "SOCIALWhatsAppFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse")]
    [AWSCmdlet("Calls the AWS End User Messaging Social CreateWhatsAppFlow API operation.", Operation = new[] {"CreateWhatsAppFlow"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse))]
    [AWSCmdletOutput("Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse",
        "This cmdlet returns an Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse object containing multiple properties."
    )]
    public partial class NewSOCIALWhatsAppFlowCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Category
        /// <summary>
        /// <para>
        /// <para>The categories that classify the business purpose of the Flow. At least one category
        /// is required.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Categories")]
        public System.String[] Category { get; set; }
        #endregion
        
        #region Parameter CloneFlowId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing Flow within the same WhatsApp Business Account to clone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloneFlowId { get; set; }
        #endregion
        
        #region Parameter FlowJson
        /// <summary>
        /// <para>
        /// <para>The Flow JSON definition that describes the screens, components, and logic of the
        /// Flow. Maximum size is 10 MB.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] FlowJson { get; set; }
        #endregion
        
        #region Parameter FlowName
        /// <summary>
        /// <para>
        /// <para>The name of the Flow. Must be unique within the WhatsApp Business Account.</para>
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
        public System.String FlowName { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the WhatsApp Business Account to associate with this Flow.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Publish
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to publish the Flow immediately after creation. Requires a valid
        /// <c>flowJson</c> that passes Meta's validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Publish { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Id),
                nameof(this.FlowName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SOCIALWhatsAppFlow (CreateWhatsAppFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse, NewSOCIALWhatsAppFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Category != null)
            {
                context.Category = new List<System.String>(this.Category);
            }
            #if MODULAR
            if (this.Category == null && ParameterWasBound(nameof(this.Category)))
            {
                WriteWarning("You are passing $null as a value for parameter Category which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloneFlowId = this.CloneFlowId;
            context.FlowJson = this.FlowJson;
            context.FlowName = this.FlowName;
            #if MODULAR
            if (this.FlowName == null && ParameterWasBound(nameof(this.FlowName)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Publish = this.Publish;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _FlowJsonStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SocialMessaging.Model.CreateWhatsAppFlowRequest();
                
                if (cmdletContext.Category != null)
                {
                    request.Categories = cmdletContext.Category;
                }
                if (cmdletContext.CloneFlowId != null)
                {
                    request.CloneFlowId = cmdletContext.CloneFlowId;
                }
                if (cmdletContext.FlowJson != null)
                {
                    _FlowJsonStream = new System.IO.MemoryStream(cmdletContext.FlowJson);
                    request.FlowJson = _FlowJsonStream;
                }
                if (cmdletContext.FlowName != null)
                {
                    request.FlowName = cmdletContext.FlowName;
                }
                if (cmdletContext.Id != null)
                {
                    request.Id = cmdletContext.Id;
                }
                if (cmdletContext.Publish != null)
                {
                    request.Publish = cmdletContext.Publish.Value;
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
            finally
            {
                if( _FlowJsonStream != null)
                {
                    _FlowJsonStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.CreateWhatsAppFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "CreateWhatsAppFlow");
            try
            {
                return client.CreateWhatsAppFlowAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Category { get; set; }
            public System.String CloneFlowId { get; set; }
            public byte[] FlowJson { get; set; }
            public System.String FlowName { get; set; }
            public System.String Id { get; set; }
            public System.Boolean? Publish { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.CreateWhatsAppFlowResponse, NewSOCIALWhatsAppFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
