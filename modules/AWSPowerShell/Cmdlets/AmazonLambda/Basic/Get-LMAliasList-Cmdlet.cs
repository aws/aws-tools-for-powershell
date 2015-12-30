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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Returns list of aliases created for a Lambda function. For each alias, the response
    /// includes information such as the alias ARN, description, alias name, and the function
    /// version to which it points. For more information, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-v2-intro-aliases.html">Introduction
    /// to AWS Lambda Aliases</a><para>
    /// This requires permission for the lambda:ListAliases action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMAliasList")]
    [OutputType("Amazon.Lambda.Model.AliasConfiguration")]
    [AWSCmdlet("Invokes the ListAliases operation against Amazon Lambda.", Operation = new[] {"ListAliases"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.AliasConfiguration",
        "This cmdlet returns a collection of AliasConfiguration objects.",
        "The service call response (type Amazon.Lambda.Model.ListAliasesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextMarker (type System.String)"
    )]
    public class GetLMAliasListCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>Lambda function name for which the alias is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter FunctionVersion
        /// <summary>
        /// <para>
        /// <para>If you specify this optional parameter, the API returns only the aliases pointing
        /// to the specific Lambda function version, otherwise returns all aliases created for
        /// the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FunctionVersion { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Optional string. An opaque pagination token returned from a previous ListAliases operation.
        /// If present, indicates where to continue the listing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Optional integer. Specifies the maximum number of aliases to return in response. This
        /// parameter value must be greater than 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.Int32 MaxItem { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.FunctionName = this.FunctionName;
            context.FunctionVersion = this.FunctionVersion;
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
            var request = new Amazon.Lambda.Model.ListAliasesRequest();
            
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.FunctionVersion != null)
            {
                request.FunctionVersion = cmdletContext.FunctionVersion;
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
                var response = client.ListAliases(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Aliases;
                notes = new Dictionary<string, object>();
                notes["NextMarker"] = response.NextMarker;
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
            public System.String FunctionName { get; set; }
            public System.String FunctionVersion { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxItems { get; set; }
        }
        
    }
}
