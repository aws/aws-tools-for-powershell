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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates an ID mapping table.
    /// </summary>
    [Cmdlet("New", "CRSIdMappingTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.IdMappingTable")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateIdMappingTable API operation.", Operation = new[] {"CreateIdMappingTable"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateIdMappingTableResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.IdMappingTable or Amazon.CleanRooms.Model.CreateIdMappingTableResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.IdMappingTable object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateIdMappingTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCRSIdMappingTableCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the ID mapping table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InputReferenceConfig_InputReferenceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the referenced resource in Entity Resolution. Valid
        /// values are ID mapping workflow ARNs.</para>
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
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services KMS key. This value is used
        /// to encrypt the mapping table data that is stored by Clean Rooms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter InputReferenceConfig_ManageResourcePolicy
        /// <summary>
        /// <para>
        /// <para>When <c>TRUE</c>, Clean Rooms manages permissions for the ID mapping table resource.
        /// </para><para>When <c>FALSE</c>, the resource owner manages permissions for the ID mapping table
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
        /// <para>The unique identifier of the membership that contains the ID mapping table.</para>
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
        /// <para>A name for the ID mapping table.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdMappingTable'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateIdMappingTableResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateIdMappingTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdMappingTable";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MembershipIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSIdMappingTable (CreateIdMappingTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateIdMappingTableResponse, NewCRSIdMappingTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
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
            context.KmsKeyArn = this.KmsKeyArn;
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
            var request = new Amazon.CleanRooms.Model.CreateIdMappingTableRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate InputReferenceConfig
            var requestInputReferenceConfigIsNull = true;
            request.InputReferenceConfig = new Amazon.CleanRooms.Model.IdMappingTableInputReferenceConfig();
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
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
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
        
        private Amazon.CleanRooms.Model.CreateIdMappingTableResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateIdMappingTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateIdMappingTable");
            try
            {
                #if DESKTOP
                return client.CreateIdMappingTable(request);
                #elif CORECLR
                return client.CreateIdMappingTableAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String InputReferenceConfig_InputReferenceArn { get; set; }
            public System.Boolean? InputReferenceConfig_ManageResourcePolicy { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateIdMappingTableResponse, NewCRSIdMappingTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdMappingTable;
        }
        
    }
}
