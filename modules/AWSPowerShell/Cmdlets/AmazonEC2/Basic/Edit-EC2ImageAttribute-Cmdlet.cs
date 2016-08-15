/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Modifies the specified attribute of the specified AMI. You can specify only one attribute
    /// at a time.
    /// 
    ///  <note><para>
    /// AWS Marketplace product codes cannot be modified. Images with an AWS Marketplace product
    /// code cannot be made public.
    /// </para></note><note><para>
    /// The SriovNetSupport enhanced networking attribute cannot be changed using this command.
    /// Instead, enable SriovNetSupport on an instance and create an AMI from the instance.
    /// This will result in an image with SriovNetSupport enabled.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "EC2ImageAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyImageAttribute operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ModifyImageAttribute"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ImageId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.ModifyImageAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEC2ImageAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter LaunchPermission_Add
        /// <summary>
        /// <para>
        /// <para>The AWS account ID to add to the list of launch permissions for the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.Model.LaunchPermission[] LaunchPermission_Add { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>The name of the attribute to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Attribute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ImageId { get; set; }
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
        /// <para>One or more product codes. After you add a product code to an AMI, it can't be removed.
        /// This is only valid when modifying the <code>productCodes</code> attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProductCodes")]
        public System.String[] ProductCode { get; set; }
        #endregion
        
        #region Parameter LaunchPermission_Remove
        /// <summary>
        /// <para>
        /// <para>The AWS account ID to remove from the list of launch permissions for the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.Model.LaunchPermission[] LaunchPermission_Remove { get; set; }
        #endregion
        
        #region Parameter UserGroup
        /// <summary>
        /// <para>
        /// <para>One or more user groups. This is only valid when modifying the <code>launchPermission</code>
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
        /// <para>One or more AWS account IDs. This is only valid when modifying the <code>launchPermission</code>
        /// attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserIds")]
        public System.String[] UserId { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>The value of the attribute being modified. This is only valid when modifying the <code>description</code>
        /// attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Value { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ImageId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ImageId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2ImageAttribute (ModifyImageAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Attribute = this.Attribute;
            context.Description = this.Description;
            context.ImageId = this.ImageId;
            if (this.LaunchPermission_Add != null)
            {
                context.LaunchPermission_Add = new List<Amazon.EC2.Model.LaunchPermission>(this.LaunchPermission_Add);
            }
            if (this.LaunchPermission_Remove != null)
            {
                context.LaunchPermission_Remove = new List<Amazon.EC2.Model.LaunchPermission>(this.LaunchPermission_Remove);
            }
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
            context.Value = this.Value;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.ModifyImageAttributeRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attribute = cmdletContext.Attribute;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            
             // populate LaunchPermission
            bool requestLaunchPermissionIsNull = true;
            request.LaunchPermission = new Amazon.EC2.Model.LaunchPermissionModifications();
            List<Amazon.EC2.Model.LaunchPermission> requestLaunchPermission_launchPermission_Add = null;
            if (cmdletContext.LaunchPermission_Add != null)
            {
                requestLaunchPermission_launchPermission_Add = cmdletContext.LaunchPermission_Add;
            }
            if (requestLaunchPermission_launchPermission_Add != null)
            {
                request.LaunchPermission.Add = requestLaunchPermission_launchPermission_Add;
                requestLaunchPermissionIsNull = false;
            }
            List<Amazon.EC2.Model.LaunchPermission> requestLaunchPermission_launchPermission_Remove = null;
            if (cmdletContext.LaunchPermission_Remove != null)
            {
                requestLaunchPermission_launchPermission_Remove = cmdletContext.LaunchPermission_Remove;
            }
            if (requestLaunchPermission_launchPermission_Remove != null)
            {
                request.LaunchPermission.Remove = requestLaunchPermission_launchPermission_Remove;
                requestLaunchPermissionIsNull = false;
            }
             // determine if request.LaunchPermission should be set to null
            if (requestLaunchPermissionIsNull)
            {
                request.LaunchPermission = null;
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
            if (cmdletContext.Value != null)
            {
                request.Value = cmdletContext.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ImageId;
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
        
        private static Amazon.EC2.Model.ModifyImageAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyImageAttributeRequest request)
        {
            return client.ModifyImageAttribute(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Attribute { get; set; }
            public System.String Description { get; set; }
            public System.String ImageId { get; set; }
            public List<Amazon.EC2.Model.LaunchPermission> LaunchPermission_Add { get; set; }
            public List<Amazon.EC2.Model.LaunchPermission> LaunchPermission_Remove { get; set; }
            public Amazon.EC2.OperationType OperationType { get; set; }
            public List<System.String> ProductCodes { get; set; }
            public List<System.String> UserGroups { get; set; }
            public List<System.String> UserIds { get; set; }
            public System.String Value { get; set; }
        }
        
    }
}
