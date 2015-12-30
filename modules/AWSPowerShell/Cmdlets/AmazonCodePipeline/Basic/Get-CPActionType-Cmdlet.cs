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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Gets a summary of all AWS CodePipeline action types associated with your account.
    /// </summary>
    [Cmdlet("Get", "CPActionType")]
    [OutputType("Amazon.CodePipeline.Model.ActionType")]
    [AWSCmdlet("Invokes the ListActionTypes operation against AWS CodePipeline.", Operation = new[] {"ListActionTypes"})]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.ActionType",
        "This cmdlet returns a collection of ActionType objects.",
        "The service call response (type Amazon.CodePipeline.Model.ListActionTypesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCPActionTypeCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        #region Parameter ActionOwnerFilter
        /// <summary>
        /// <para>
        /// <para>Filters the list of action types to those created by a specified entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodePipeline.ActionOwner")]
        public Amazon.CodePipeline.ActionOwner ActionOwnerFilter { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An identifier that was returned from the previous list action types call, which can
        /// be used to return the next set of action types in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ActionOwnerFilter = this.ActionOwnerFilter;
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodePipeline.Model.ListActionTypesRequest();
            
            if (cmdletContext.ActionOwnerFilter != null)
            {
                request.ActionOwnerFilter = cmdletContext.ActionOwnerFilter;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListActionTypes(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ActionTypes;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
            public Amazon.CodePipeline.ActionOwner ActionOwnerFilter { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
