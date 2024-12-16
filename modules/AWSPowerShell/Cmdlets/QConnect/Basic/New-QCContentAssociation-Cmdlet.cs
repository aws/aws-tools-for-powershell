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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Creates an association between a content resource in a knowledge base and <a href="https://docs.aws.amazon.com/connect/latest/adminguide/step-by-step-guided-experiences.html">step-by-step
    /// guides</a>. Step-by-step guides offer instructions to agents for resolving common
    /// customer issues. You create a content association to integrate Amazon Q in Connect
    /// and step-by-step guides. 
    /// 
    ///  
    /// <para>
    /// After you integrate Amazon Q and step-by-step guides, when Amazon Q provides a recommendation
    /// to an agent based on the intent that it's detected, it also provides them with the
    /// option to start the step-by-step guide that you have associated with the content.
    /// </para><para>
    /// Note the following limitations:
    /// </para><ul><li><para>
    /// You can create only one content association for each content resource in a knowledge
    /// base.
    /// </para></li><li><para>
    /// You can associate a step-by-step guide with multiple content resources.
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/integrate-q-with-guides.html">Integrate
    /// Amazon Q in Connect with step-by-step guides</a> in the <i>Amazon Connect Administrator
    /// Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "QCContentAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.ContentAssociationData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateContentAssociation API operation.", Operation = new[] {"CreateContentAssociation"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateContentAssociationResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.ContentAssociationData or Amazon.QConnect.Model.CreateContentAssociationResponse",
        "This cmdlet returns an Amazon.QConnect.Model.ContentAssociationData object.",
        "The service call response (type Amazon.QConnect.Model.CreateContentAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewQCContentAssociationCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociationType
        /// <summary>
        /// <para>
        /// <para>The type of association.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.ContentAssociationType")]
        public Amazon.QConnect.ContentAssociationType AssociationType { get; set; }
        #endregion
        
        #region Parameter ContentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the content.</para>
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
        public System.String ContentId { get; set; }
        #endregion
        
        #region Parameter AmazonConnectGuideAssociation_FlowId
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of an Amazon Connect flow. Step-by-step guides are
        /// a type of flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Association_AmazonConnectGuideAssociation_FlowId")]
        public System.String AmazonConnectGuideAssociation_FlowId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContentAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateContentAssociationResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateContentAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContentAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCContentAssociation (CreateContentAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateContentAssociationResponse, NewQCContentAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmazonConnectGuideAssociation_FlowId = this.AmazonConnectGuideAssociation_FlowId;
            context.AssociationType = this.AssociationType;
            #if MODULAR
            if (this.AssociationType == null && ParameterWasBound(nameof(this.AssociationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ContentId = this.ContentId;
            #if MODULAR
            if (this.ContentId == null && ParameterWasBound(nameof(this.ContentId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.CreateContentAssociationRequest();
            
            
             // populate Association
            var requestAssociationIsNull = true;
            request.Association = new Amazon.QConnect.Model.ContentAssociationContents();
            Amazon.QConnect.Model.AmazonConnectGuideAssociationData requestAssociation_association_AmazonConnectGuideAssociation = null;
            
             // populate AmazonConnectGuideAssociation
            var requestAssociation_association_AmazonConnectGuideAssociationIsNull = true;
            requestAssociation_association_AmazonConnectGuideAssociation = new Amazon.QConnect.Model.AmazonConnectGuideAssociationData();
            System.String requestAssociation_association_AmazonConnectGuideAssociation_amazonConnectGuideAssociation_FlowId = null;
            if (cmdletContext.AmazonConnectGuideAssociation_FlowId != null)
            {
                requestAssociation_association_AmazonConnectGuideAssociation_amazonConnectGuideAssociation_FlowId = cmdletContext.AmazonConnectGuideAssociation_FlowId;
            }
            if (requestAssociation_association_AmazonConnectGuideAssociation_amazonConnectGuideAssociation_FlowId != null)
            {
                requestAssociation_association_AmazonConnectGuideAssociation.FlowId = requestAssociation_association_AmazonConnectGuideAssociation_amazonConnectGuideAssociation_FlowId;
                requestAssociation_association_AmazonConnectGuideAssociationIsNull = false;
            }
             // determine if requestAssociation_association_AmazonConnectGuideAssociation should be set to null
            if (requestAssociation_association_AmazonConnectGuideAssociationIsNull)
            {
                requestAssociation_association_AmazonConnectGuideAssociation = null;
            }
            if (requestAssociation_association_AmazonConnectGuideAssociation != null)
            {
                request.Association.AmazonConnectGuideAssociation = requestAssociation_association_AmazonConnectGuideAssociation;
                requestAssociationIsNull = false;
            }
             // determine if request.Association should be set to null
            if (requestAssociationIsNull)
            {
                request.Association = null;
            }
            if (cmdletContext.AssociationType != null)
            {
                request.AssociationType = cmdletContext.AssociationType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContentId != null)
            {
                request.ContentId = cmdletContext.ContentId;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
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
        
        private Amazon.QConnect.Model.CreateContentAssociationResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateContentAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateContentAssociation");
            try
            {
                #if DESKTOP
                return client.CreateContentAssociation(request);
                #elif CORECLR
                return client.CreateContentAssociationAsync(request).GetAwaiter().GetResult();
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
            public System.String AmazonConnectGuideAssociation_FlowId { get; set; }
            public Amazon.QConnect.ContentAssociationType AssociationType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContentId { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateContentAssociationResponse, NewQCContentAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContentAssociation;
        }
        
    }
}
