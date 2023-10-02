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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified attribute of the specified Amazon FPGA Image (AFI).
    /// </summary>
    [Cmdlet("Edit", "EC2FpgaImageAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.FpgaImageAttribute")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyFpgaImageAttribute API operation.", Operation = new[] {"ModifyFpgaImageAttribute"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyFpgaImageAttributeResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.FpgaImageAttribute or Amazon.EC2.Model.ModifyFpgaImageAttributeResponse",
        "This cmdlet returns an Amazon.EC2.Model.FpgaImageAttribute object.",
        "The service call response (type Amazon.EC2.Model.ModifyFpgaImageAttributeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2FpgaImageAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoadPermission_Add
        /// <summary>
        /// <para>
        /// <para>The load permissions to add.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.LoadPermissionRequest[] LoadPermission_Add { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The name of the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.EC2.FpgaImageAttributeName")]
        public Amazon.EC2.FpgaImageAttributeName Attribute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the AFI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FpgaImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AFI.</para>
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
        public System.String FpgaImageId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the AFI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OperationType
        /// <summary>
        /// <para>
        /// <para>The operation type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.OperationType")]
        public Amazon.EC2.OperationType OperationType { get; set; }
        #endregion
        
        #region Parameter ProductCode
        /// <summary>
        /// <para>
        /// <para>The product codes. After you add a product code to an AFI, it can't be removed. This
        /// parameter is valid only when modifying the <code>productCodes</code> attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProductCodes")]
        public System.String[] ProductCode { get; set; }
        #endregion
        
        #region Parameter LoadPermission_Remove
        /// <summary>
        /// <para>
        /// <para>The load permissions to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EC2.Model.LoadPermissionRequest[] LoadPermission_Remove { get; set; }
        #endregion
        
        #region Parameter UserGroup
        /// <summary>
        /// <para>
        /// <para>The user groups. This parameter is valid only when modifying the <code>loadPermission</code>
        /// attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserGroups")]
        public System.String[] UserGroup { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account IDs. This parameter is valid only when modifying the
        /// <code>loadPermission</code> attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserIds")]
        public System.String[] UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FpgaImageAttribute'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyFpgaImageAttributeResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyFpgaImageAttributeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FpgaImageAttribute";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Attribute parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Attribute' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Attribute' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Attribute), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2FpgaImageAttribute (ModifyFpgaImageAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyFpgaImageAttributeResponse, EditEC2FpgaImageAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Attribute;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Attribute = this.Attribute;
            context.Description = this.Description;
            context.FpgaImageId = this.FpgaImageId;
            #if MODULAR
            if (this.FpgaImageId == null && ParameterWasBound(nameof(this.FpgaImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter FpgaImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LoadPermission_Add != null)
            {
                context.LoadPermission_Add = new List<Amazon.EC2.Model.LoadPermissionRequest>(this.LoadPermission_Add);
            }
            if (this.LoadPermission_Remove != null)
            {
                context.LoadPermission_Remove = new List<Amazon.EC2.Model.LoadPermissionRequest>(this.LoadPermission_Remove);
            }
            context.Name = this.Name;
            context.OperationType = this.OperationType;
            if (this.ProductCode != null)
            {
                context.ProductCode = new List<System.String>(this.ProductCode);
            }
            if (this.UserGroup != null)
            {
                context.UserGroup = new List<System.String>(this.UserGroup);
            }
            if (this.UserId != null)
            {
                context.UserId = new List<System.String>(this.UserId);
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
            var request = new Amazon.EC2.Model.ModifyFpgaImageAttributeRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attribute = cmdletContext.Attribute;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FpgaImageId != null)
            {
                request.FpgaImageId = cmdletContext.FpgaImageId;
            }
            
             // populate LoadPermission
            var requestLoadPermissionIsNull = true;
            request.LoadPermission = new Amazon.EC2.Model.LoadPermissionModifications();
            List<Amazon.EC2.Model.LoadPermissionRequest> requestLoadPermission_loadPermission_Add = null;
            if (cmdletContext.LoadPermission_Add != null)
            {
                requestLoadPermission_loadPermission_Add = cmdletContext.LoadPermission_Add;
            }
            if (requestLoadPermission_loadPermission_Add != null)
            {
                request.LoadPermission.Add = requestLoadPermission_loadPermission_Add;
                requestLoadPermissionIsNull = false;
            }
            List<Amazon.EC2.Model.LoadPermissionRequest> requestLoadPermission_loadPermission_Remove = null;
            if (cmdletContext.LoadPermission_Remove != null)
            {
                requestLoadPermission_loadPermission_Remove = cmdletContext.LoadPermission_Remove;
            }
            if (requestLoadPermission_loadPermission_Remove != null)
            {
                request.LoadPermission.Remove = requestLoadPermission_loadPermission_Remove;
                requestLoadPermissionIsNull = false;
            }
             // determine if request.LoadPermission should be set to null
            if (requestLoadPermissionIsNull)
            {
                request.LoadPermission = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OperationType != null)
            {
                request.OperationType = cmdletContext.OperationType;
            }
            if (cmdletContext.ProductCode != null)
            {
                request.ProductCodes = cmdletContext.ProductCode;
            }
            if (cmdletContext.UserGroup != null)
            {
                request.UserGroups = cmdletContext.UserGroup;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserIds = cmdletContext.UserId;
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
        
        private Amazon.EC2.Model.ModifyFpgaImageAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyFpgaImageAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyFpgaImageAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyFpgaImageAttribute(request);
                #elif CORECLR
                return client.ModifyFpgaImageAttributeAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.FpgaImageAttributeName Attribute { get; set; }
            public System.String Description { get; set; }
            public System.String FpgaImageId { get; set; }
            public List<Amazon.EC2.Model.LoadPermissionRequest> LoadPermission_Add { get; set; }
            public List<Amazon.EC2.Model.LoadPermissionRequest> LoadPermission_Remove { get; set; }
            public System.String Name { get; set; }
            public Amazon.EC2.OperationType OperationType { get; set; }
            public List<System.String> ProductCode { get; set; }
            public List<System.String> UserGroup { get; set; }
            public List<System.String> UserId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyFpgaImageAttributeResponse, EditEC2FpgaImageAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FpgaImageAttribute;
        }
        
    }
}
