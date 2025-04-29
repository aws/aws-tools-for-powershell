/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Personalize;
using Amazon.Personalize.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PERS
{
    /// <summary>
    /// Describes a recipe.
    /// 
    ///  
    /// <para>
    /// A recipe contains three items:
    /// </para><ul><li><para>
    /// An algorithm that trains a model.
    /// </para></li><li><para>
    /// Hyperparameters that govern the training.
    /// </para></li><li><para>
    /// Feature transformation information for modifying the input data before training.
    /// </para></li></ul><para>
    /// Amazon Personalize provides a set of predefined recipes. You specify a recipe when
    /// you create a solution with the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_CreateSolution.html">CreateSolution</a>
    /// API. <c>CreateSolution</c> trains a model by using the algorithm in the specified
    /// recipe and a training dataset. The solution, when deployed as a campaign, can provide
    /// recommendations using the <a href="https://docs.aws.amazon.com/personalize/latest/dg/API_RS_GetRecommendations.html">GetRecommendations</a>
    /// API.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "PERSRecipe")]
    [OutputType("Amazon.Personalize.Model.Recipe")]
    [AWSCmdlet("Calls the AWS Personalize DescribeRecipe API operation.", Operation = new[] {"DescribeRecipe"}, SelectReturnType = typeof(Amazon.Personalize.Model.DescribeRecipeResponse))]
    [AWSCmdletOutput("Amazon.Personalize.Model.Recipe or Amazon.Personalize.Model.DescribeRecipeResponse",
        "This cmdlet returns an Amazon.Personalize.Model.Recipe object.",
        "The service call response (type Amazon.Personalize.Model.DescribeRecipeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPERSRecipeCmdlet : AmazonPersonalizeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RecipeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recipe to describe.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RecipeArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Recipe'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Personalize.Model.DescribeRecipeResponse).
        /// Specifying the name of a property of type Amazon.Personalize.Model.DescribeRecipeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Recipe";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Personalize.Model.DescribeRecipeResponse, GetPERSRecipeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RecipeArn = this.RecipeArn;
            #if MODULAR
            if (this.RecipeArn == null && ParameterWasBound(nameof(this.RecipeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecipeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Personalize.Model.DescribeRecipeRequest();
            
            if (cmdletContext.RecipeArn != null)
            {
                request.RecipeArn = cmdletContext.RecipeArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.Personalize.Model.DescribeRecipeResponse CallAWSServiceOperation(IAmazonPersonalize client, Amazon.Personalize.Model.DescribeRecipeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Personalize", "DescribeRecipe");
            try
            {
                return client.DescribeRecipeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RecipeArn { get; set; }
            public System.Func<Amazon.Personalize.Model.DescribeRecipeResponse, GetPERSRecipeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Recipe;
        }
        
    }
}
