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
    /// Creates a computer account in the specified directory, and joins the computer to the
    /// directory.
    /// </summary>
    [Cmdlet("New", "DSComputer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectoryService.Model.Computer")]
    [AWSCmdlet("Invokes the CreateComputer operation against AWS Directory Service.", Operation = new[] {"CreateComputer"})]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.Computer",
        "This cmdlet returns a Computer object.",
        "The service call response (type Amazon.DirectoryService.Model.CreateComputerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewDSComputerCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ComputerAttribute
        /// <summary>
        /// <para>
        /// <para>An array of <a>Attribute</a> objects that contain any LDAP attributes to apply to
        /// the computer account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ComputerAttributes")]
        public Amazon.DirectoryService.Model.Attribute[] ComputerAttribute { get; set; }
        #endregion
        
        #region Parameter ComputerName
        /// <summary>
        /// <para>
        /// <para>The name of the computer account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ComputerName { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory in which to create the computer account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>The fully-qualified distinguished name of the organizational unit to place the computer
        /// account in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OrganizationalUnitDistinguishedName { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>A one-time password that is used to join the computer to the directory. You should
        /// generate a random, strong password to use for this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Password { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSComputer (CreateComputer)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ComputerAttribute != null)
            {
                context.ComputerAttributes = new List<Amazon.DirectoryService.Model.Attribute>(this.ComputerAttribute);
            }
            context.ComputerName = this.ComputerName;
            context.DirectoryId = this.DirectoryId;
            context.OrganizationalUnitDistinguishedName = this.OrganizationalUnitDistinguishedName;
            context.Password = this.Password;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DirectoryService.Model.CreateComputerRequest();
            
            if (cmdletContext.ComputerAttributes != null)
            {
                request.ComputerAttributes = cmdletContext.ComputerAttributes;
            }
            if (cmdletContext.ComputerName != null)
            {
                request.ComputerName = cmdletContext.ComputerName;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.OrganizationalUnitDistinguishedName != null)
            {
                request.OrganizationalUnitDistinguishedName = cmdletContext.OrganizationalUnitDistinguishedName;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateComputer(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Computer;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.DirectoryService.Model.Attribute> ComputerAttributes { get; set; }
            public System.String ComputerName { get; set; }
            public System.String DirectoryId { get; set; }
            public System.String OrganizationalUnitDistinguishedName { get; set; }
            public System.String Password { get; set; }
        }
        
    }
}
