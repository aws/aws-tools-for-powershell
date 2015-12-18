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
    /// Obtains information about the trust relationships for this account.
    /// 
    ///  
    /// <para>
    /// If no input parameters are provided, such as DirectoryId or TrustIds, this request
    /// describes all the trust relationships belonging to the account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DSTrust")]
    [OutputType("Amazon.DirectoryService.Model.Trust")]
    [AWSCmdlet("Invokes the DescribeTrusts operation against AWS Directory Service.", Operation = new[] {"DescribeTrusts"})]
    [AWSCmdletOutput("Amazon.DirectoryService.Model.Trust",
        "This cmdlet returns a collection of Trust objects.",
        "The service call response (type Amazon.DirectoryService.Model.DescribeTrustsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetDSTrustCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// The Directory ID of the AWS directory that
        /// is a part of the requested trust relationship.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter TrustId
        /// <summary>
        /// <para>
        /// <para>A list of identifiers of the trust relationships for which to obtain the information.
        /// If this member is null, all trust relationships that belong to the current account
        /// are returned.</para><para>An empty list results in an <code>InvalidParameterException</code> being thrown.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TrustIds")]
        public System.String[] TrustId { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// The maximum number of objects to return.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <i>DescribeTrustsResult.NextToken</i> value from a previous call to <a>DescribeTrusts</a>.
        /// Pass null if this is the first call.</para>
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
            
            context.DirectoryId = this.DirectoryId;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            if (this.TrustId != null)
            {
                context.TrustIds = new List<System.String>(this.TrustId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DirectoryService.Model.DescribeTrustsRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.TrustIds != null)
            {
                request.TrustIds = cmdletContext.TrustIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeTrusts(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Trusts;
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
            public System.String DirectoryId { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> TrustIds { get; set; }
        }
        
    }
}
