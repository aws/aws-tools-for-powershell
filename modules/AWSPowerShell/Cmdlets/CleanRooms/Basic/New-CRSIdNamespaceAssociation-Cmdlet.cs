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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates an ID namespace association.
    /// </summary>
    [Cmdlet("New", "CRSIdNamespaceAssociation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.IdNamespaceAssociation")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateIdNamespaceAssociation API operation.", Operation = new[] {"CreateIdNamespaceAssociation"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateIdNamespaceAssociationResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.IdNamespaceAssociation or Amazon.CleanRooms.Model.CreateIdNamespaceAssociationResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.IdNamespaceAssociation object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateIdNamespaceAssociationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRSIdNamespaceAssociationCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdMappingConfig_AllowUseAsDimensionColumn
        /// <summary>
        /// <para>
        /// <para>An indicator as to whether you can use your column as a dimension column in the ID
        /// mapping table (<c>TRUE</c>) or not (<c>FALSE</c>).</para><para>Default is <c>FALSE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IdMappingConfig_AllowUseAsDimensionColumn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the ID namespace association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InputReferenceConfig_InputReferenceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Entity Resolution resource that is being associated
        /// to the collaboration. Valid resource ARNs are from the ID namespaces that you own.</para>
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
        public System.String InputReferenceConfig_InputReferenceArn { get; set; }
        #endregion
        
        #region Parameter InputReferenceConfig_ManageResourcePolicy
        /// <summary>
        /// <para>
        /// <para>When <c>TRUE</c>, Clean Rooms manages permissions for the ID namespace association
        /// resource.</para><para>When <c>FALSE</c>, the resource owner manages permissions for the ID namespace association
        /// resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InputReferenceConfig_ManageResourcePolicies")]
        public System.Boolean? InputReferenceConfig_ManageResourcePolicy { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the membership that contains the ID namespace association.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the ID namespace association.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional label that you can assign to a resource when you create it. Each tag consists
        /// of a key and an optional value, both of which you define. When you use tagging, you
        /// can also use tag-based access control in IAM policies to control access to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdNamespaceAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateIdNamespaceAssociationResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateIdNamespaceAssociationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdNamespaceAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSIdNamespaceAssociation (CreateIdNamespaceAssociation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateIdNamespaceAssociationResponse, NewCRSIdNamespaceAssociationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.IdMappingConfig_AllowUseAsDimensionColumn = this.IdMappingConfig_AllowUseAsDimensionColumn;
            context.InputReferenceConfig_InputReferenceArn = this.InputReferenceConfig_InputReferenceArn;
            #if MODULAR
            if (this.InputReferenceConfig_InputReferenceArn == null && ParameterWasBound(nameof(this.InputReferenceConfig_InputReferenceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InputReferenceConfig_InputReferenceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputReferenceConfig_ManageResourcePolicy = this.InputReferenceConfig_ManageResourcePolicy;
            #if MODULAR
            if (this.InputReferenceConfig_ManageResourcePolicy == null && ParameterWasBound(nameof(this.InputReferenceConfig_ManageResourcePolicy)))
            {
                WriteWarning("You are passing $null as a value for parameter InputReferenceConfig_ManageResourcePolicy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CleanRooms.Model.CreateIdNamespaceAssociationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate IdMappingConfig
            var requestIdMappingConfigIsNull = true;
            request.IdMappingConfig = new Amazon.CleanRooms.Model.IdMappingConfig();
            System.Boolean? requestIdMappingConfig_idMappingConfig_AllowUseAsDimensionColumn = null;
            if (cmdletContext.IdMappingConfig_AllowUseAsDimensionColumn != null)
            {
                requestIdMappingConfig_idMappingConfig_AllowUseAsDimensionColumn = cmdletContext.IdMappingConfig_AllowUseAsDimensionColumn.Value;
            }
            if (requestIdMappingConfig_idMappingConfig_AllowUseAsDimensionColumn != null)
            {
                request.IdMappingConfig.AllowUseAsDimensionColumn = requestIdMappingConfig_idMappingConfig_AllowUseAsDimensionColumn.Value;
                requestIdMappingConfigIsNull = false;
            }
             // determine if request.IdMappingConfig should be set to null
            if (requestIdMappingConfigIsNull)
            {
                request.IdMappingConfig = null;
            }
            
             // populate InputReferenceConfig
            var requestInputReferenceConfigIsNull = true;
            request.InputReferenceConfig = new Amazon.CleanRooms.Model.IdNamespaceAssociationInputReferenceConfig();
            System.String requestInputReferenceConfig_inputReferenceConfig_InputReferenceArn = null;
            if (cmdletContext.InputReferenceConfig_InputReferenceArn != null)
            {
                requestInputReferenceConfig_inputReferenceConfig_InputReferenceArn = cmdletContext.InputReferenceConfig_InputReferenceArn;
            }
            if (requestInputReferenceConfig_inputReferenceConfig_InputReferenceArn != null)
            {
                request.InputReferenceConfig.InputReferenceArn = requestInputReferenceConfig_inputReferenceConfig_InputReferenceArn;
                requestInputReferenceConfigIsNull = false;
            }
            System.Boolean? requestInputReferenceConfig_inputReferenceConfig_ManageResourcePolicy = null;
            if (cmdletContext.InputReferenceConfig_ManageResourcePolicy != null)
            {
                requestInputReferenceConfig_inputReferenceConfig_ManageResourcePolicy = cmdletContext.InputReferenceConfig_ManageResourcePolicy.Value;
            }
            if (requestInputReferenceConfig_inputReferenceConfig_ManageResourcePolicy != null)
            {
                request.InputReferenceConfig.ManageResourcePolicies = requestInputReferenceConfig_inputReferenceConfig_ManageResourcePolicy.Value;
                requestInputReferenceConfigIsNull = false;
            }
             // determine if request.InputReferenceConfig should be set to null
            if (requestInputReferenceConfigIsNull)
            {
                request.InputReferenceConfig = null;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
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
        
        private Amazon.CleanRooms.Model.CreateIdNamespaceAssociationResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateIdNamespaceAssociationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateIdNamespaceAssociation");
            try
            {
                return client.CreateIdNamespaceAssociationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? IdMappingConfig_AllowUseAsDimensionColumn { get; set; }
            public System.String InputReferenceConfig_InputReferenceArn { get; set; }
            public System.Boolean? InputReferenceConfig_ManageResourcePolicy { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateIdNamespaceAssociationResponse, NewCRSIdNamespaceAssociationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdNamespaceAssociation;
        }
        
    }
}
