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
using Amazon.SSMIncidents;
using Amazon.SSMIncidents.Model;

namespace Amazon.PowerShell.Cmdlets.SSMI
{
    /// <summary>
    /// Add or remove related items from the related items tab of an incident record.
    /// </summary>
    [Cmdlet("Update", "SSMIRelatedItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager UpdateRelatedItems API operation.", Operation = new[] {"UpdateRelatedItems"}, SelectReturnType = typeof(Amazon.SSMIncidents.Model.UpdateRelatedItemsResponse))]
    [AWSCmdletOutput("None or Amazon.SSMIncidents.Model.UpdateRelatedItemsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSMIncidents.Model.UpdateRelatedItemsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSMIRelatedItemCmdlet : AmazonSSMIncidentsClientCmdlet, IExecutor
    {
        
        #region Parameter RelatedItemsUpdate_ItemToAdd_Identifier_Value_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the related item, if the related item is an Amazon
        /// resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedItemsUpdate_ItemToAdd_Identifier_Value_Arn { get; set; }
        #endregion
        
        #region Parameter RelatedItemsUpdate_ItemToRemove_Value_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the related item, if the related item is an Amazon
        /// resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedItemsUpdate_ItemToRemove_Value_Arn { get; set; }
        #endregion
        
        #region Parameter IncidentRecordArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the incident record containing the related items
        /// you are updating.</para>
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
        public System.String IncidentRecordArn { get; set; }
        #endregion
        
        #region Parameter RelatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition
        /// <summary>
        /// <para>
        /// <para>The metric definition, if the related item is a metric in Amazon CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition { get; set; }
        #endregion
        
        #region Parameter RelatedItemsUpdate_ItemToRemove_Value_MetricDefinition
        /// <summary>
        /// <para>
        /// <para>The metric definition, if the related item is a metric in Amazon CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedItemsUpdate_ItemToRemove_Value_MetricDefinition { get; set; }
        #endregion
        
        #region Parameter ItemToAdd_Title
        /// <summary>
        /// <para>
        /// <para>The title of the related item.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RelatedItemsUpdate_ItemToAdd_Title")]
        public System.String ItemToAdd_Title { get; set; }
        #endregion
        
        #region Parameter Identifier_Type
        /// <summary>
        /// <para>
        /// <para>The type of related item. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RelatedItemsUpdate_ItemToAdd_Identifier_Type")]
        [AWSConstantClassSource("Amazon.SSMIncidents.ItemType")]
        public Amazon.SSMIncidents.ItemType Identifier_Type { get; set; }
        #endregion
        
        #region Parameter ItemToRemove_Type
        /// <summary>
        /// <para>
        /// <para>The type of related item. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RelatedItemsUpdate_ItemToRemove_Type")]
        [AWSConstantClassSource("Amazon.SSMIncidents.ItemType")]
        public Amazon.SSMIncidents.ItemType ItemToRemove_Type { get; set; }
        #endregion
        
        #region Parameter RelatedItemsUpdate_ItemToAdd_Identifier_Value_Url
        /// <summary>
        /// <para>
        /// <para>The URL, if the related item is a non-Amazon Web Services resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedItemsUpdate_ItemToAdd_Identifier_Value_Url { get; set; }
        #endregion
        
        #region Parameter RelatedItemsUpdate_ItemToRemove_Value_Url
        /// <summary>
        /// <para>
        /// <para>The URL, if the related item is a non-Amazon Web Services resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedItemsUpdate_ItemToRemove_Value_Url { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token ensuring that the operation is called only once with the specified details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMIncidents.Model.UpdateRelatedItemsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IncidentRecordArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IncidentRecordArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IncidentRecordArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IncidentRecordArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMIRelatedItem (UpdateRelatedItems)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMIncidents.Model.UpdateRelatedItemsResponse, UpdateSSMIRelatedItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IncidentRecordArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.IncidentRecordArn = this.IncidentRecordArn;
            #if MODULAR
            if (this.IncidentRecordArn == null && ParameterWasBound(nameof(this.IncidentRecordArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IncidentRecordArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Identifier_Type = this.Identifier_Type;
            context.RelatedItemsUpdate_ItemToAdd_Identifier_Value_Arn = this.RelatedItemsUpdate_ItemToAdd_Identifier_Value_Arn;
            context.RelatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition = this.RelatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition;
            context.RelatedItemsUpdate_ItemToAdd_Identifier_Value_Url = this.RelatedItemsUpdate_ItemToAdd_Identifier_Value_Url;
            context.ItemToAdd_Title = this.ItemToAdd_Title;
            context.ItemToRemove_Type = this.ItemToRemove_Type;
            context.RelatedItemsUpdate_ItemToRemove_Value_Arn = this.RelatedItemsUpdate_ItemToRemove_Value_Arn;
            context.RelatedItemsUpdate_ItemToRemove_Value_MetricDefinition = this.RelatedItemsUpdate_ItemToRemove_Value_MetricDefinition;
            context.RelatedItemsUpdate_ItemToRemove_Value_Url = this.RelatedItemsUpdate_ItemToRemove_Value_Url;
            
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
            var request = new Amazon.SSMIncidents.Model.UpdateRelatedItemsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.IncidentRecordArn != null)
            {
                request.IncidentRecordArn = cmdletContext.IncidentRecordArn;
            }
            
             // populate RelatedItemsUpdate
            var requestRelatedItemsUpdateIsNull = true;
            request.RelatedItemsUpdate = new Amazon.SSMIncidents.Model.RelatedItemsUpdate();
            Amazon.SSMIncidents.Model.RelatedItem requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd = null;
            
             // populate ItemToAdd
            var requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAddIsNull = true;
            requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd = new Amazon.SSMIncidents.Model.RelatedItem();
            System.String requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_itemToAdd_Title = null;
            if (cmdletContext.ItemToAdd_Title != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_itemToAdd_Title = cmdletContext.ItemToAdd_Title;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_itemToAdd_Title != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd.Title = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_itemToAdd_Title;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAddIsNull = false;
            }
            Amazon.SSMIncidents.Model.ItemIdentifier requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier = null;
            
             // populate Identifier
            var requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_IdentifierIsNull = true;
            requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier = new Amazon.SSMIncidents.Model.ItemIdentifier();
            Amazon.SSMIncidents.ItemType requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_identifier_Type = null;
            if (cmdletContext.Identifier_Type != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_identifier_Type = cmdletContext.Identifier_Type;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_identifier_Type != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier.Type = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_identifier_Type;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_IdentifierIsNull = false;
            }
            Amazon.SSMIncidents.Model.ItemValue requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value = null;
            
             // populate Value
            var requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_ValueIsNull = true;
            requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value = new Amazon.SSMIncidents.Model.ItemValue();
            System.String requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_Arn = null;
            if (cmdletContext.RelatedItemsUpdate_ItemToAdd_Identifier_Value_Arn != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_Arn = cmdletContext.RelatedItemsUpdate_ItemToAdd_Identifier_Value_Arn;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_Arn != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value.Arn = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_Arn;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_ValueIsNull = false;
            }
            System.String requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition = null;
            if (cmdletContext.RelatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition = cmdletContext.RelatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value.MetricDefinition = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_ValueIsNull = false;
            }
            System.String requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_Url = null;
            if (cmdletContext.RelatedItemsUpdate_ItemToAdd_Identifier_Value_Url != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_Url = cmdletContext.RelatedItemsUpdate_ItemToAdd_Identifier_Value_Url;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_Url != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value.Url = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value_relatedItemsUpdate_ItemToAdd_Identifier_Value_Url;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_ValueIsNull = false;
            }
             // determine if requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value should be set to null
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_ValueIsNull)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value = null;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier.Value = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier_relatedItemsUpdate_ItemToAdd_Identifier_Value;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_IdentifierIsNull = false;
            }
             // determine if requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier should be set to null
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_IdentifierIsNull)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier = null;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd.Identifier = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd_relatedItemsUpdate_ItemToAdd_Identifier;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAddIsNull = false;
            }
             // determine if requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd should be set to null
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAddIsNull)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd = null;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd != null)
            {
                request.RelatedItemsUpdate.ItemToAdd = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToAdd;
                requestRelatedItemsUpdateIsNull = false;
            }
            Amazon.SSMIncidents.Model.ItemIdentifier requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove = null;
            
             // populate ItemToRemove
            var requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemoveIsNull = true;
            requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove = new Amazon.SSMIncidents.Model.ItemIdentifier();
            Amazon.SSMIncidents.ItemType requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_itemToRemove_Type = null;
            if (cmdletContext.ItemToRemove_Type != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_itemToRemove_Type = cmdletContext.ItemToRemove_Type;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_itemToRemove_Type != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove.Type = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_itemToRemove_Type;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemoveIsNull = false;
            }
            Amazon.SSMIncidents.Model.ItemValue requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value = null;
            
             // populate Value
            var requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_ValueIsNull = true;
            requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value = new Amazon.SSMIncidents.Model.ItemValue();
            System.String requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_Arn = null;
            if (cmdletContext.RelatedItemsUpdate_ItemToRemove_Value_Arn != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_Arn = cmdletContext.RelatedItemsUpdate_ItemToRemove_Value_Arn;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_Arn != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value.Arn = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_Arn;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_ValueIsNull = false;
            }
            System.String requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_MetricDefinition = null;
            if (cmdletContext.RelatedItemsUpdate_ItemToRemove_Value_MetricDefinition != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_MetricDefinition = cmdletContext.RelatedItemsUpdate_ItemToRemove_Value_MetricDefinition;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_MetricDefinition != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value.MetricDefinition = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_MetricDefinition;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_ValueIsNull = false;
            }
            System.String requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_Url = null;
            if (cmdletContext.RelatedItemsUpdate_ItemToRemove_Value_Url != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_Url = cmdletContext.RelatedItemsUpdate_ItemToRemove_Value_Url;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_Url != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value.Url = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value_relatedItemsUpdate_ItemToRemove_Value_Url;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_ValueIsNull = false;
            }
             // determine if requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value should be set to null
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_ValueIsNull)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value = null;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value != null)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove.Value = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove_relatedItemsUpdate_ItemToRemove_Value;
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemoveIsNull = false;
            }
             // determine if requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove should be set to null
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemoveIsNull)
            {
                requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove = null;
            }
            if (requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove != null)
            {
                request.RelatedItemsUpdate.ItemToRemove = requestRelatedItemsUpdate_relatedItemsUpdate_ItemToRemove;
                requestRelatedItemsUpdateIsNull = false;
            }
             // determine if request.RelatedItemsUpdate should be set to null
            if (requestRelatedItemsUpdateIsNull)
            {
                request.RelatedItemsUpdate = null;
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
        
        private Amazon.SSMIncidents.Model.UpdateRelatedItemsResponse CallAWSServiceOperation(IAmazonSSMIncidents client, Amazon.SSMIncidents.Model.UpdateRelatedItemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager", "UpdateRelatedItems");
            try
            {
                #if DESKTOP
                return client.UpdateRelatedItems(request);
                #elif CORECLR
                return client.UpdateRelatedItemsAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String IncidentRecordArn { get; set; }
            public Amazon.SSMIncidents.ItemType Identifier_Type { get; set; }
            public System.String RelatedItemsUpdate_ItemToAdd_Identifier_Value_Arn { get; set; }
            public System.String RelatedItemsUpdate_ItemToAdd_Identifier_Value_MetricDefinition { get; set; }
            public System.String RelatedItemsUpdate_ItemToAdd_Identifier_Value_Url { get; set; }
            public System.String ItemToAdd_Title { get; set; }
            public Amazon.SSMIncidents.ItemType ItemToRemove_Type { get; set; }
            public System.String RelatedItemsUpdate_ItemToRemove_Value_Arn { get; set; }
            public System.String RelatedItemsUpdate_ItemToRemove_Value_MetricDefinition { get; set; }
            public System.String RelatedItemsUpdate_ItemToRemove_Value_Url { get; set; }
            public System.Func<Amazon.SSMIncidents.Model.UpdateRelatedItemsResponse, UpdateSSMIRelatedItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
