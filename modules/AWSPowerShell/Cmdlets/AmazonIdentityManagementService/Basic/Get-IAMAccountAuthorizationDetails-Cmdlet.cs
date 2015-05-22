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
    /// Retrieves information about all IAM users, groups, roles, and policies in your account,
    /// including their relationships to one another. Use this API to obtain a snapshot of
    /// the configuration of IAM permissions (users, groups, roles, and policies) in your
    /// account.
    /// 
    ///  
    /// <para>
    /// You can optionally filter the results using the <code>Filter</code> parameter. You
    /// can paginate the results using the <code>MaxItems</code> and <code>Marker</code> parameters.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMAccountAuthorizationDetails")]
    [OutputType("Amazon.IdentityManagement.Model.GetAccountAuthorizationDetailsResponse")]
    [AWSCmdlet("Invokes the GetAccountAuthorizationDetails operation against AWS Identity and Access Management.", Operation = new[] {"GetAccountAuthorizationDetails"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.GetAccountAuthorizationDetailsResponse",
        "This cmdlet returns a GetAccountAuthorizationDetailsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetIAMAccountAuthorizationDetailsCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A list of entity types (user, group, role, local managed policy, or AWS managed policy)
        /// for filtering the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use this only when paginating results, and only in a subsequent request after you've
        /// received a response where the results are truncated. Set it to the value of the <code>Marker</code>
        /// element in the response you just received.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Use this only when paginating results to indicate the maximum number of items you
        /// want in the response. If there are additional items beyond the maximum you specify,
        /// the <code>IsTruncated</code> response element is <code>true</code>. This parameter
        /// is optional. If you do not include it, it defaults to 100.</para>
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
            
            if (this.Filter != null)
            {
                context.Filter = new List<String>(this.Filter);
            }
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetAccountAuthorizationDetailsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = cmdletContext.MaxItems.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetAccountAuthorizationDetails(request);
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
            public List<String> Filter { get; set; }
            public String Marker { get; set; }
            public Int32? MaxItems { get; set; }
        }
        
    }
}
