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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates a directory configuration.
    /// </summary>
    [Cmdlet("New", "APSDirectoryConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.DirectoryConfig")]
    [AWSCmdlet("Invokes the CreateDirectoryConfig operation against AWS AppStream.", Operation = new[] {"CreateDirectoryConfig"})]
    [AWSCmdletOutput("Amazon.AppStream.Model.DirectoryConfig",
        "This cmdlet returns a DirectoryConfig object.",
        "The service call response (type Amazon.AppStream.Model.CreateDirectoryConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAPSDirectoryConfigCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        #region Parameter ServiceAccountCredentials_AccountName
        /// <summary>
        /// <para>
        /// <para>The user name of the account. This account must have the following privileges: create
        /// computer objects, join computers to the domain, and change/reset the password on descendant
        /// computer objects for the organizational units specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceAccountCredentials_AccountName { get; set; }
        #endregion
        
        #region Parameter ServiceAccountCredentials_AccountPassword
        /// <summary>
        /// <para>
        /// <para>The password for the account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceAccountCredentials_AccountPassword { get; set; }
        #endregion
        
        #region Parameter DirectoryName
        /// <summary>
        /// <para>
        /// <para>The fully qualified name of the directory (for example, corp.example.com).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryName { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>The distinguished names of the organizational units for computer accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OrganizationalUnitDistinguishedNames")]
        public System.String[] OrganizationalUnitDistinguishedName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSDirectoryConfig (CreateDirectoryConfig)"))
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
            
            context.DirectoryName = this.DirectoryName;
            if (this.OrganizationalUnitDistinguishedName != null)
            {
                context.OrganizationalUnitDistinguishedNames = new List<System.String>(this.OrganizationalUnitDistinguishedName);
            }
            context.ServiceAccountCredentials_AccountName = this.ServiceAccountCredentials_AccountName;
            context.ServiceAccountCredentials_AccountPassword = this.ServiceAccountCredentials_AccountPassword;
            
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
            var request = new Amazon.AppStream.Model.CreateDirectoryConfigRequest();
            
            if (cmdletContext.DirectoryName != null)
            {
                request.DirectoryName = cmdletContext.DirectoryName;
            }
            if (cmdletContext.OrganizationalUnitDistinguishedNames != null)
            {
                request.OrganizationalUnitDistinguishedNames = cmdletContext.OrganizationalUnitDistinguishedNames;
            }
            
             // populate ServiceAccountCredentials
            bool requestServiceAccountCredentialsIsNull = true;
            request.ServiceAccountCredentials = new Amazon.AppStream.Model.ServiceAccountCredentials();
            System.String requestServiceAccountCredentials_serviceAccountCredentials_AccountName = null;
            if (cmdletContext.ServiceAccountCredentials_AccountName != null)
            {
                requestServiceAccountCredentials_serviceAccountCredentials_AccountName = cmdletContext.ServiceAccountCredentials_AccountName;
            }
            if (requestServiceAccountCredentials_serviceAccountCredentials_AccountName != null)
            {
                request.ServiceAccountCredentials.AccountName = requestServiceAccountCredentials_serviceAccountCredentials_AccountName;
                requestServiceAccountCredentialsIsNull = false;
            }
            System.String requestServiceAccountCredentials_serviceAccountCredentials_AccountPassword = null;
            if (cmdletContext.ServiceAccountCredentials_AccountPassword != null)
            {
                requestServiceAccountCredentials_serviceAccountCredentials_AccountPassword = cmdletContext.ServiceAccountCredentials_AccountPassword;
            }
            if (requestServiceAccountCredentials_serviceAccountCredentials_AccountPassword != null)
            {
                request.ServiceAccountCredentials.AccountPassword = requestServiceAccountCredentials_serviceAccountCredentials_AccountPassword;
                requestServiceAccountCredentialsIsNull = false;
            }
             // determine if request.ServiceAccountCredentials should be set to null
            if (requestServiceAccountCredentialsIsNull)
            {
                request.ServiceAccountCredentials = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DirectoryConfig;
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
        
        private Amazon.AppStream.Model.CreateDirectoryConfigResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateDirectoryConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppStream", "CreateDirectoryConfig");
            try
            {
                #if DESKTOP
                return client.CreateDirectoryConfig(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDirectoryConfigAsync(request);
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
            public System.String DirectoryName { get; set; }
            public List<System.String> OrganizationalUnitDistinguishedNames { get; set; }
            public System.String ServiceAccountCredentials_AccountName { get; set; }
            public System.String ServiceAccountCredentials_AccountPassword { get; set; }
        }
        
    }
}
