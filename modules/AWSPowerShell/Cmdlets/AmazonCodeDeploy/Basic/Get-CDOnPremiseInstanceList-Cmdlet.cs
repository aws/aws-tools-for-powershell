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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Gets a list of one or more on-premises instance names.
    /// 
    ///  
    /// <para>
    /// Unless otherwise specified, both registered and deregistered on-premises instance
    /// names will be listed. To list only registered or deregistered on-premises instance
    /// names, use the registration status parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CDOnPremiseInstanceList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListOnPremisesInstances operation against AWS CodeDeploy.", Operation = new[] {"ListOnPremisesInstances"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.CodeDeploy.Model.ListOnPremisesInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetCDOnPremiseInstanceListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The on-premises instances registration status:</para><ul><li>Deregistered: Include in the resulting list deregistered on-premises instances.</li><li>Registered: Include in the resulting list registered on-premises instances.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CodeDeploy.RegistrationStatus RegistrationStatus { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The on-premises instance tags that will be used to restrict the corresponding on-premises
        /// instance names that are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagFilters")]
        public Amazon.CodeDeploy.Model.TagFilter[] TagFilter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An identifier that was returned from the previous list on-premises instances call,
        /// which can be used to return the next set of on-premises instances in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.NextToken = this.NextToken;
            context.RegistrationStatus = this.RegistrationStatus;
            if (this.TagFilter != null)
            {
                context.TagFilters = new List<Amazon.CodeDeploy.Model.TagFilter>(this.TagFilter);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeDeploy.Model.ListOnPremisesInstancesRequest();
            
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.RegistrationStatus != null)
            {
                request.RegistrationStatus = cmdletContext.RegistrationStatus;
            }
            if (cmdletContext.TagFilters != null)
            {
                request.TagFilters = cmdletContext.TagFilters;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListOnPremisesInstances(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceNames;
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
            public System.String NextToken { get; set; }
            public Amazon.CodeDeploy.RegistrationStatus RegistrationStatus { get; set; }
            public List<Amazon.CodeDeploy.Model.TagFilter> TagFilters { get; set; }
        }
        
    }
}
