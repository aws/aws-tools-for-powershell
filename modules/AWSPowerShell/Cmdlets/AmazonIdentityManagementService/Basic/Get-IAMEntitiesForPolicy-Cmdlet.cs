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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Lists all users, groups, and roles that the specified managed policy is attached to.
    /// 
    /// 
    ///  
    /// <para>
    /// You can use the optional <code>EntityFilter</code> parameter to limit the results
    /// to a particular type of entity (users, groups, or roles). For example, to list only
    /// the roles that are attached to the specified policy, set <code>EntityFilter</code>
    /// to <code>Role</code>. 
    /// </para><para>
    /// You can paginate the results using the <code>MaxItems</code> and <code>Marker</code>
    /// parameters. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMEntitiesForPolicy")]
    [OutputType("Amazon.IdentityManagement.Model.ListEntitiesForPolicyResponse")]
    [AWSCmdlet("Invokes the ListEntitiesForPolicy operation against AWS Identity and Access Management.", Operation = new[] {"ListEntitiesForPolicy"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.ListEntitiesForPolicyResponse",
        "This cmdlet returns a ListEntitiesForPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetIAMEntitiesForPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The entity type to use for filtering the results. </para><para>For example, when <code>EntityFilter</code> is <code>Role</code>, only the roles that
        /// are attached to the specified policy are returned. This parameter is optional. If
        /// it is not included, all attached entities (users, groups, and roles) are returned.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public EntityType EntityFilter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The path prefix for filtering the results. This parameter is optional. If it is not
        /// included, it defaults to a slash (/), listing all entities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PathPrefix { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String PolicyArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use this parameter only when paginating results and only after you receive a response
        /// indicating that the results are truncated. Set it to the value of the <code>Marker</code>
        /// element in the response you received to inform the next call about where to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use this only when paginating results to indicate the maximum number of items you
        /// want in the response. If there are additional items beyond the maximum you specify,
        /// the <code>IsTruncated</code> response element is <code>true</code>.</para><para>This parameter is optional. If you do not include it, it defaults to 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public Int32 MaxItem { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.EntityFilter = this.EntityFilter;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            context.PathPrefix = this.PathPrefix;
            context.PolicyArn = this.PolicyArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ListEntitiesForPolicyRequest();
            
            if (cmdletContext.EntityFilter != null)
            {
                request.EntityFilter = cmdletContext.EntityFilter;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems.Value;
            }
            if (cmdletContext.PathPrefix != null)
            {
                request.PathPrefix = cmdletContext.PathPrefix;
            }
            if (cmdletContext.PolicyArn != null)
            {
                request.PolicyArn = cmdletContext.PolicyArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListEntitiesForPolicy(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
            public EntityType EntityFilter { get; set; }
            public String Marker { get; set; }
            public Int32? MaxItems { get; set; }
            public String PathPrefix { get; set; }
            public String PolicyArn { get; set; }
        }
        
    }
}
