/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyFpgaImageAttribute API operation.", Operation = new[] {"ModifyFpgaImageAttribute"})]
    [AWSCmdletOutput("Amazon.EC2.Model.FpgaImageAttribute",
        "This cmdlet returns a FpgaImageAttribute object.",
        "The service call response (type Amazon.EC2.Model.ModifyFpgaImageAttributeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2FpgaImageAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter LoadPermission_Add
        /// <summary>
        /// <para>
        /// <para>The load permissions to add.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.Model.LoadPermissionRequest[] LoadPermission_Add { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The name of the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.EC2.FpgaImageAttributeName")]
        public Amazon.EC2.FpgaImageAttributeName Attribute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the AFI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FpgaImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AFI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FpgaImageId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the AFI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OperationType
        /// <summary>
        /// <para>
        /// <para>The operation type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.OperationType")]
        public Amazon.EC2.OperationType OperationType { get; set; }
        #endregion
        
        #region Parameter ProductCode
        /// <summary>
        /// <para>
        /// <para>One or more product codes. After you add a product code to an AFI, it can't be removed.
        /// This parameter is valid only when modifying the <code>productCodes</code> attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProductCodes")]
        public System.String[] ProductCode { get; set; }
        #endregion
        
        #region Parameter LoadPermission_Remove
        /// <summary>
        /// <para>
        /// <para>The load permissions to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.Model.LoadPermissionRequest[] LoadPermission_Remove { get; set; }
        #endregion
        
        #region Parameter UserGroup
        /// <summary>
        /// <para>
        /// <para>One or more user groups. This parameter is valid only when modifying the <code>loadPermission</code>
        /// attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserGroups")]
        public System.String[] UserGroup { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>One or more AWS account IDs. This parameter is valid only when modifying the <code>loadPermission</code>
        /// attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserIds")]
        public System.String[] UserId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Attribute", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2FpgaImageAttribute (ModifyFpgaImageAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Attribute = this.Attribute;
            context.Description = this.Description;
            context.FpgaImageId = this.FpgaImageId;
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
                context.ProductCodes = new List<System.String>(this.ProductCode);
            }
            if (this.UserGroup != null)
            {
                context.UserGroups = new List<System.String>(this.UserGroup);
            }
            if (this.UserId != null)
            {
                context.UserIds = new List<System.String>(this.UserId);
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
            bool requestLoadPermissionIsNull = true;
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
            if (cmdletContext.ProductCodes != null)
            {
                request.ProductCodes = cmdletContext.ProductCodes;
            }
            if (cmdletContext.UserGroups != null)
            {
                request.UserGroups = cmdletContext.UserGroups;
            }
            if (cmdletContext.UserIds != null)
            {
                request.UserIds = cmdletContext.UserIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FpgaImageAttribute;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyFpgaImageAttribute");
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
            public List<System.String> ProductCodes { get; set; }
            public List<System.String> UserGroups { get; set; }
            public List<System.String> UserIds { get; set; }
        }
        
    }
}
