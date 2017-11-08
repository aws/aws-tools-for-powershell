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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Creates a Microsoft AD in the AWS cloud.
    /// 
    ///  
    /// <para>
    /// Before you call <i>CreateMicrosoftAD</i>, ensure that all of the required permissions
    /// have been explicitly granted through a policy. For details about what permissions
    /// are required to run the <i>CreateMicrosoftAD</i> operation, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/UsingWithDS_IAM_ResourcePermissions.html">AWS
    /// Directory Service API Permissions: Actions, Resources, and Conditions Reference</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSMicrosoftAD", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Directory Service CreateMicrosoftAD API operation.", Operation = new[] {"CreateMicrosoftAD"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.DirectoryService.Model.CreateMicrosoftADResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSMicrosoftADCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A textual description for the directory. This label will appear on the AWS console
        /// <code>Directory Details</code> page after the directory is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name for the directory, such as <code>corp.example.com</code>.
        /// This name will resolve inside your VPC only. It does not need to be publicly resolvable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password for the default administrative user named <code>Admin</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter ShortName
        /// <summary>
        /// <para>
        /// <para>The NetBIOS name for your domain. A short identifier for your domain, such as <code>CORP</code>.
        /// If you don't specify a NetBIOS name, it will default to the first part of your directory
        /// DNS. For example, <code>CORP</code> for the directory DNS <code>corp.example.com</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ShortName { get; set; }
        #endregion
        
        #region Parameter VpcSettings_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets for the directory servers. The two subnets must be
        /// in different Availability Zones. AWS Directory Service creates a directory server
        /// and a DNS server in each of these subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcSettings_SubnetIds")]
        public System.String[] VpcSettings_SubnetId { get; set; }
        #endregion
        
        #region Parameter VpcSettings_VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC in which to create the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VpcSettings_VpcId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSMicrosoftAD (CreateMicrosoftAD)"))
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
            
            context.Description = this.Description;
            context.Name = this.Name;
            context.Password = this.Password;
            context.ShortName = this.ShortName;
            if (this.VpcSettings_SubnetId != null)
            {
                context.VpcSettings_SubnetIds = new List<System.String>(this.VpcSettings_SubnetId);
            }
            context.VpcSettings_VpcId = this.VpcSettings_VpcId;
            
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
            var request = new Amazon.DirectoryService.Model.CreateMicrosoftADRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.ShortName != null)
            {
                request.ShortName = cmdletContext.ShortName;
            }
            
             // populate VpcSettings
            bool requestVpcSettingsIsNull = true;
            request.VpcSettings = new Amazon.DirectoryService.Model.DirectoryVpcSettings();
            List<System.String> requestVpcSettings_vpcSettings_SubnetId = null;
            if (cmdletContext.VpcSettings_SubnetIds != null)
            {
                requestVpcSettings_vpcSettings_SubnetId = cmdletContext.VpcSettings_SubnetIds;
            }
            if (requestVpcSettings_vpcSettings_SubnetId != null)
            {
                request.VpcSettings.SubnetIds = requestVpcSettings_vpcSettings_SubnetId;
                requestVpcSettingsIsNull = false;
            }
            System.String requestVpcSettings_vpcSettings_VpcId = null;
            if (cmdletContext.VpcSettings_VpcId != null)
            {
                requestVpcSettings_vpcSettings_VpcId = cmdletContext.VpcSettings_VpcId;
            }
            if (requestVpcSettings_vpcSettings_VpcId != null)
            {
                request.VpcSettings.VpcId = requestVpcSettings_vpcSettings_VpcId;
                requestVpcSettingsIsNull = false;
            }
             // determine if request.VpcSettings should be set to null
            if (requestVpcSettingsIsNull)
            {
                request.VpcSettings = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DirectoryId;
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
        
        private Amazon.DirectoryService.Model.CreateMicrosoftADResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.CreateMicrosoftADRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "CreateMicrosoftAD");
            try
            {
                #if DESKTOP
                return client.CreateMicrosoftAD(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateMicrosoftADAsync(request);
                return task.Result;
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
            public System.String Name { get; set; }
            public System.String Password { get; set; }
            public System.String ShortName { get; set; }
            public List<System.String> VpcSettings_SubnetIds { get; set; }
            public System.String VpcSettings_VpcId { get; set; }
        }
        
    }
}
